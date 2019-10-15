const jwt = require("jsonwebtoken");

const { SECRET } = require('../config').config;

module.exports = (req, res, next) => {
  if (req.headers.token) {
    verfiyToken(req, res)
  } else {
    generateToken(res);
  }

  next();
}

function generateToken(res) {
  const token = jwt.sign({ token: "bootcamp" }, SECRET);
  res.setHeader("token", token);
}

function verfiyToken(req, res) {
  const token = req.headers.token;

  const result = jwt.verify(token, SECRET, (err) => {
    res.send({
      auth: false,
      message: err.message
    })
  });
}