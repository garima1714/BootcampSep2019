const userschemas =require('../model/schema')

module.exports = {
  getUsers,
  createUser,
  updateUser,
  deleteUser
};

const users = [];

async function getUsers() {
  return await userschemas.find()
}

async function createUser(req, res) {
  let response,body,details
  body =req.body
  details = new userschemas(body)
  console.log(details)
  try{
    response =await details.save()
    return response
  }
  catch(err)
  {
    response = {error:err}
    return response
  }
}

async function updateUser(req, res) {
  _id = req.query.id
  response = await userschemas.findByIdAndUpdate(_id,req.body,{new: true})
  return response
}

async function deleteUser(req, res) {

  const _id = req.query.id
  const response = await userschemas.findByIdAndRemove(_id);
  res.send(response)
}