var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var NhomSchema = new Schema({
  id: { type: "String", required: true },
  tenNhom: { type: "String", required: true },
  loai: { type: "String", required: true },
  icon: { type: "String", required: false }
});

var Nhom = mongoose.model("Nhom", NhomSchema);

module.exports = Nhom;
