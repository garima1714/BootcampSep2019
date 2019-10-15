var mongoose = require('mongoose');
  var Schema = mongoose.Schema;

  var userschema = new Schema({
    Name:  String,
    Age: String,
    Add: [{ State: String, Zip: Date }]
  });

  module.exports = mongoose.model('userschema',userschema);