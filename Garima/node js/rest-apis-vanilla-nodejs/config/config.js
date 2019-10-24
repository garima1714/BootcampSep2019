const { cmdLineParser } = require("../utils/utils");

const configObj = cmdLineParser(process.argv);
console.log(configObj);

module.exports = {
  PORT: process.env.PORT || configObj.PORT || 9000,
  HOST: process.env.HOST || configObj.HOST || "0.0.0.0",
  baseURI: process.env.baseURI || configObj.baseURI || "/api",
  database: {
    DB_USER: process.env.DB_USER || configObj.DB_USER || "admin",
    DB_PASSWORD: process.env.DB_PASSWORD || configObj.DB_PASSWORD || "root"
  }
};
