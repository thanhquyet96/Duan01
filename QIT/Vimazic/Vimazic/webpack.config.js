/// <binding AfterBuild='Run - Development' />
var env = (process.env.NODE_ENV || "development").trim()
if (env === 'production') {
  module.exports = require(`./wwwroot/build/webpack.prod.conf.js`);
} else {
  module.exports = require(`./wwwroot/build/webpack.dev.conf.js`);
}
