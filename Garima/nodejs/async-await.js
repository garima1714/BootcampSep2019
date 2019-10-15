function checkNum(num) {
  return new Promise(function (resolve, reject) {
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

async function run() {
  try {
    console.log("run started!");

    const res1 = await mockDBFetch(5);
    console.log(res1);

    // const res2 = await checkNum("2"); // throws error here. Stops further execution.
    // console.log(res2);

    const res3 = await mockDBFetch(3);
    console.log(res3);

    const res4 = await checkNum(2);
    console.log(res4);

    console.log("run finished!");
  } catch (e) {
    console.error(e);
  }
}

function caller() {
  console.log("caller started!");

  run();

  const sum = 2 + 2;
  console.log(sum);

  console.log("caller finished!");
}
// caller();

async function async_caller() {
  console.log("caller started!");

  await run();

  const sum = 2 + 2;
  console.log(sum);

  console.log("caller finished!");
}
async_caller();

function print() {
  console.log("I'm also running!");
}
print();
