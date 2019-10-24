const fs = require('fs')


class BaseController {
  async create(req,res) {
    try {
      req.on("end", () => {
        readFile().then(data => {
          this.users.push(JSON.parse(data));
          //this.users = JSON.parse(data);
          console.log(this.users);

          const user = req.body;
          this.users.push(user);

          writeFile(this.users);

          const response = {
            status: 200,
            statusText: "OK",
            message: "Client Inserted!"
          };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        });
      });
    } catch (err) {
      console.error(err);
    }
  }
  async read(req,res) {
    try {
      readFile()
        .then(data => {
          console.log(data)
          this.users = JSON.parse(data);

          const response = { total: this.users.length, data: this.users };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        })
        .catch(err => {
          const response = { error: err };

          res.setHeader("content-type", "application/json");
          res.end(JSON.stringify(response));
        });
    } catch (err) {
      console.error(err);
    }
  }
  async update(req,res) {
    try {
      req.on("end", () => {
        let query = req.query;

        console.log(query);

        const id = Number.parseInt(query.id);
        const user = req.body;

        this.users[id] = user;

        const response = {
          status: 200,
          statusText: "OK",
          message: "Client Updated!"
        };

        res.setHeader("content-type", "application/json");
        res.end(JSON.stringify(response));
      });
    } catch (err) {
      console.error(err);
    }
  }
  async delete(req,res) {
    try {
    } catch (err) {
      console.error(err);
    }
  }
}


exports.BaseController = BaseController;

function readFile() {
  //const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.readFile("input.json", "utf-8");
}

function writeFile(data) {
  //const dbPath = path.join(__dirname, "../db", "users.json");
  return fs.promises.writeFile("input.json", JSON.stringify(data));
  }
