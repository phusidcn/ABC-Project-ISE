var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var SaveSchema = new Schema({
  id: { type: "String", required: true },
  tenVi: { type: "String", required: true },
  soTien: { type: "Number", required: true },
  icon: { type: "String", required: false }
});

var Save = mongoose.model("Save", SaveSchema);

module.exports = Save;
