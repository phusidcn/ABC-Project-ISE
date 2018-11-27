var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var SonoSchema = new Schema({
  loai: {type: 'String'},
  nguoilq: {type: 'String'},
  ngayhen: {type: 'String'}
});

var Sono = mongoose.model("Sono", SonoSchema);

module.exports = Sono;
