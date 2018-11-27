var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var STKSchema = new Schema({
  id: { type: "String", required: true },
  tenSTK: { type: "String", required: true },
  soTien: { type: "Number", required: true },
  muctieu: { type: "String", required: false },
  mucdich: {type: "String", required: false},
  ngayKT: {type: "String", required: true},
});

var STK = mongoose.model("STK", STKSchema);

module.exports = STK;
