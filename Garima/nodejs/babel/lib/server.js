"use strict";

var _express = _interopRequireDefault(require("express"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

var app = (0, _express["default"])();
var _process$env = process.env,
    _process$env$PORT = _process$env.PORT,
    PORT = _process$env$PORT === void 0 ? 9000 : _process$env$PORT,
    _process$env$HOST = _process$env.HOST,
    HOST = _process$env$HOST === void 0 ? "0.0.0.0" : _process$env$HOST;
app.listen(PORT, HOST, function (err) {
  try {
    console.log("running on http://".concat(HOST, ":").concat(PORT));
  } catch (err) {
    console.error(err);
  }
});