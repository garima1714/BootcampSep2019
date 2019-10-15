import express from "express";

const app = express();

const { PORT = 9000, HOST = "0.0.0.0" } = process.env;

app.listen(PORT, HOST, err => {
  try {
    console.log(`running on http://${HOST}:${PORT}`);
  } catch (err) {
    console.error(err);
  }
});
