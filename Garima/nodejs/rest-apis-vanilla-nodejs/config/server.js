const http = require("http");

const { PORT, HOST } = require("./config");
const { queryStringParser } = require("../utils/utils");

const router = require("../routes/router");

const server = http.createServer((req, res) => {
  req.on("data", chunk => {
    // console.log("chunk:", chunk);

    req.body = JSON.parse(Buffer.from(chunk, "utf-8").toString());

    // console.log(req);
  });

  router(req, res);
});

server.on("request", (req, res) => {
  if (req.url.includes("?")) queryStringParser(req);
});

server.listen(PORT, HOST, err => {
  if (err) throw err;
  console.log(`Runnnig on: http://${HOST}:${PORT}`);
});
