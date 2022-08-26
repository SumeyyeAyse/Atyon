const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:21914';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/firma/list",
      "/firma/add",
      "/firma/put",
      "/firma/delete",
      "/tesis/list",
      "/tesis/add",
      "/tesis/put",
      "/tesis/delete",
      "/atik/list",
      "/atik/add",
      "/atik/put",
      "/atik/delete",
   ],
    target: target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
