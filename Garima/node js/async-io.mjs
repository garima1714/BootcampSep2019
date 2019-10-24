import path from "path";
import { readFile, writeFile } from "fs";

const dataDumpPath = path.join("dump.txt");

var data = "aakash";
writeDataAfterTimeOut(1000, dataDumpPath, data);

readDataAfterTimeOut(1500, dataDumpPath);

data = "ankit";
writeDataAfterTimeOut(4000, dataDumpPath, data);

readDataAfterTimeOut(5000, dataDumpPath);

data = "zeeshan";
writeDataAfterTimeOut(6000, dataDumpPath, data);

readDataAfterTimeOut(
  10000,
  dataDumpPath,
  "Data read at 10000 seconds started!"
);

data = "captain america";
writeDataAfterTimeOut(10000, dataDumpPath);

data = "DANGER";
readDataAfterTimeOut(10000, dataDumpPath);
writeDataAfterTimeOut(10000, dataDumpPath, data);

function writeDataAfterTimeOut(time, path, data) {
  setTimeout(() => {
    writeFile(path, data, err => {
      if (err) throw err;
      console.log("Data written to file!");
    });
  }, time);
}

function readDataAfterTimeOut(time, path, message) {
  setTimeout(() => {
    readFile(path, "utf-8", (err, data) => {
      if (err) throw err;

      if (message) {
        console.log(message, "data:", data);
      }

      console.log("Data:", data);
    });
  }, time);
}
