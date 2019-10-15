const { Router } = require("express");

const { baseURI } = require("../config").config;

const { users } = require("../controllers")

module.exports = () => {
  const router = Router();

  router.get(`${baseURI}/users`, users.getUsers);
  router.post(`${baseURI}/users`, users.createUser);
  router.patch(`${baseURI}/users`, users.updateUser);
  router.delete(`${baseURI}/users`, users.deleteUser);

  return router;
}