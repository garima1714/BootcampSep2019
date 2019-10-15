const { user } = require("../models");

module.exports = {
  getUsers,
  createUser,
  updateUser,
  deleteUser
};

async function getUsers(req, res) {
  const response = await user.getUsers(req,res);
  res.send(JSON.stringify(response))
}

async function createUser(req, res) {
  const response = await user.createUser(req,res);
  res.send(JSON.stringify(response))
}

async function updateUser(req, res) {
  console.log('update')
  const response = await user.updateUser(req,res);
  res.send(JSON.stringify(response))
}

async function deleteUser(req, res) {
  const response = await user.deleteUser(req,res);
  res.send(JSON.stringify(response))
}