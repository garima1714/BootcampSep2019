const { baseURI } = require("../config").config;
const { Users } = require("../controller");

const routes = {
  users: `${baseURI}/users`
};

module.exports = (req, res) => {
  const url = req.url.includes("?")
    ? req.url.substr(0, req.url.lastIndexOf("?"))
    : req.url;

  switch (url) {
    case routes.users:
      users(req, res, req.method);
      break;
  }
};

function users(req, res, reqMethod) {
  const users = new Users();

  switch (reqMethod) {
    case "GET":
      users.getUsers(req, res);
      break;
    case "POST":
      users.createUser(req, res);
      break;
    case "PATCH":
      users.updateUser(req, res);
      break;
    case "DELETE":
      users.deleteUser(req, res);
      break;
  }
}
