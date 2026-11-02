// Draws the ```mermaid blocks of a wiki page. Markdig renders them as
// <pre class="mermaid">; the colours come from theme.css like the rest of the site.
(() => {
  if (!window.mermaid) {
    return;
  }

  const style = getComputedStyle(document.documentElement);
  const v = name => style.getPropertyValue(name).trim();

  window.mermaid.initialize({
    startOnLoad: false,
    securityLevel: "strict",
    theme: "base",
    fontFamily: v("--ss-font-body"),
    themeVariables: {
      darkMode: true,
      background: v("--ss-black"),
      fontFamily: v("--ss-font-body"),
      primaryColor: v("--ss-panel"),
      primaryBorderColor: v("--ss-orange"),
      primaryTextColor: v("--ss-text"),
      secondaryColor: v("--ss-media-ember"),
      secondaryBorderColor: v("--ss-gold"),
      secondaryTextColor: v("--ss-text"),
      tertiaryColor: v("--ss-media-steel"),
      tertiaryBorderColor: v("--ss-grey"),
      tertiaryTextColor: v("--ss-text"),
      lineColor: v("--ss-grey"),
      textColor: v("--ss-text"),
      mainBkg: v("--ss-panel"),
      nodeBorder: v("--ss-orange"),
      clusterBkg: v("--ss-black"),
      clusterBorder: v("--ss-panel-border"),
      titleColor: v("--ss-gold"),
      edgeLabelBackground: v("--ss-black"),
      actorBkg: v("--ss-panel"),
      actorBorder: v("--ss-orange"),
      actorTextColor: v("--ss-text"),
      actorLineColor: v("--ss-grey"),
      signalColor: v("--ss-text"),
      signalTextColor: v("--ss-text"),
      labelBoxBkgColor: v("--ss-panel"),
      labelBoxBorderColor: v("--ss-orange"),
      labelTextColor: v("--ss-text"),
      loopTextColor: v("--ss-text"),
      noteBkgColor: v("--ss-media-ember"),
      noteBorderColor: v("--ss-gold"),
      noteTextColor: v("--ss-text"),
      sectionBkgColor: v("--ss-panel"),
      altSectionBkgColor: v("--ss-black"),
      sectionBkgColor2: v("--ss-media-steel"),
      taskBkgColor: v("--ss-orange"),
      taskBorderColor: v("--ss-gold"),
      taskTextColor: v("--ss-on-primary"),
      taskTextOutsideColor: v("--ss-text"),
      doneTaskBkgColor: v("--ss-grey"),
      activeTaskBkgColor: v("--ss-gold"),
      critBkgColor: v("--ss-orange-hover"),
      gridColor: v("--ss-panel-border"),
      todayLineColor: v("--ss-cyan"),
    },
  });

  // Text is measured to size the boxes, so wait for the UO font first.
  document.fonts.ready.then(() => window.mermaid.run({ querySelector: ".wiki-content .mermaid" }));
})();
