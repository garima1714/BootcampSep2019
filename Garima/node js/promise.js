function checkNum(num) {
  return new Promise(function(resolve, reject) {
    if (typeof num === "number") {
      resolve(num);
    } else {
      const message = `typeof num is ${typeof num}. Expected Number`;
      reject(message);
    }
  });
}

function mockDBFetch(timer) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const users = [
        {
          name: "Aakash",
          age: 26,
          country: "India"
        },
        {
          name: "Ankit",
          age: 24,
          country: "India"
        },
        {
          name: "Xavier",
          age: 70,
          country: "Unknown"
        }
      ];
      resolve(`${timer} - seconds - ${JSON.stringify(users)}`);
    }, 1000 * timer);
  });
}

mockDBFetch(5)
  .then(result => console.log(result))
  .catch(err => console.error(err));

checkNum("2")
  .then(result => console.log("Resolve:", result))
  .catch(err => console.error("Error:", err));

mockDBFetch(3)
  .then(result => console.log(result))
  .catch(err => console.error(err));

checkNum(2)
  .then(result => console.log("Resolve:", result))
  .catch(err => console.error("Error:", err));
