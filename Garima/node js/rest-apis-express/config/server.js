const express = require("express");
const bodyParser = require("body-parser");

const auth = require("../auth/authenticator");

const apiRouter = require('../router/apiRouter');

const { PORT, HOST } = require("./config");

const server = express();

var mongoose = require('mongoose');
mongoose.connect('mongodb://127.0.0.1:27017/dbase1', {useNewUrlParser: true, useCreateIndex:true});
var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function() {
 console.log("mongoose connected");
});



server.use(bodyParser({
  extended: false
}));

server.use(auth, apiRouter());

server.listen(PORT, HOST, err => {
  if (err) throw err;
  console.log(`Runnnig on: http://${HOST}:${PORT}`);
});

exports.default={server,mongoose};
