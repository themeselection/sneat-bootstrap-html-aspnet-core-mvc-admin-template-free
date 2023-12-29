module.exports = {
  base: {
    // Excludes folders relative to `root` directory.
    exclude: [
      'html',
      'html-starter',
      'html-demo',
      'dist',
      'build',
      'assets',
      'tasks',
      'node_modules',
      '_temp',
      'node-script'
    ]
  },
  development: {
    // Build path can be both relative or absolute.
    // Current dist path is `./assets/vendor` which will be used by templates from `html\` directory. Set distPath: './dist' to generate assets in dist folder.
    distPath: './wwwroot',

    // Minify assets.
    minify: false,

    // Generate sourcemaps.
    sourcemaps: false,

    // https://webpack.js.org/configuration/devtool/#development
    devtool: 'eval-source-map',

    // Remove sourcemaps, *.dist.js and *.dist.css files before build
    cleanDist: true,
    fastDev: true
  },
  production: {
    // Build path can be both relative or absolute.
    // Current dist path is `./assets/vendor` which will be used by templates from `html\` directory. Set distPath: './dist' to generate assets in dist folder.
    distPath: './wwwroot',

    // Minify assets.
    // Note: Webpack will minify js sources in production mode regardless to this option
    minify: true,

    // Generate sourcemaps.

    sourcemaps: false,
    // https://webpack.js.org/configuration/devtool/#production
    devtool: '#source-map',

    // Remove sourcemaps, *.dist.js and *.dist.css files before build
    cleanDist: true,
    fastDev: false
  }
};
