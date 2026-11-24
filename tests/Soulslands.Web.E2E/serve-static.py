"""Serves a dist/ folder of the static site like Cloudflare Pages does, for the browser tests.

python3 -m http.server plus two Pages behaviours: the headers of the "/*" rule of _headers (so the
Content-Security-Policy applies) and 404.html for a path without a file. Prints "PORT <n>" once
listening on 127.0.0.1. Usage: python3 serve-static.py <dist> [port]
"""

import functools
import http.server
import os
import sys


def read_headers(dist):
    headers = []
    in_root = False
    try:
        with open(os.path.join(dist, "_headers"), encoding="utf-8") as f:
            for line in f:
                if not line.strip():
                    in_root = False
                    continue
                if line.startswith("#"):
                    continue
                if not line.startswith(" "):
                    in_root = line.strip() == "/*"
                    continue
                if in_root:
                    name, _, value = line.strip().partition(":")
                    headers.append((name.strip(), value.strip()))
    except FileNotFoundError:
        pass
    return headers


class Handler(http.server.SimpleHTTPRequestHandler):
    extra_headers = []

    def end_headers(self):
        for name, value in self.extra_headers:
            self.send_header(name, value)
        super().end_headers()

    def send_error(self, code, message=None, explain=None):
        page = os.path.join(self.directory, "404.html")
        if code != 404 or not os.path.exists(page):
            return super().send_error(code, message, explain)
        with open(page, "rb") as f:
            body = f.read()
        self.send_response(404)
        self.send_header("Content-Type", "text/html; charset=utf-8")
        self.send_header("Content-Length", str(len(body)))
        self.end_headers()
        if self.command != "HEAD":
            self.wfile.write(body)

    def log_message(self, format, *args):
        pass


def main():
    dist = os.path.abspath(sys.argv[1])
    port = int(sys.argv[2]) if len(sys.argv) > 2 else 0
    Handler.extra_headers = read_headers(dist)
    handler = functools.partial(Handler, directory=dist)
    with http.server.ThreadingHTTPServer(("127.0.0.1", port), handler) as server:
        print(f"PORT {server.server_address[1]}", flush=True)
        server.serve_forever()


if __name__ == "__main__":
    main()
