const fs = require("fs"),
  path = require("path");

const { BaseController } = require("./BaseController");

class Users extends BaseController {
  constructor() {
    super();
    this.users = [];
  }

  async getUsers(req, res) {
    super.read(req, res);
  }

  async createUser(req, res) {
    super.create(req, res); 
  }

  async updateUser(req, res) {
    super.update(req, res);
  }

  async deleteUser(req, res) {
    super.delete(req, res);
}
}

exports.Users = Users
