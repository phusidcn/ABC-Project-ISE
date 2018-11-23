var mongoose = require('mongoose');
 var Schema = mongoose.Schema;

 var SaveSchema = new Schema({
   text: {type: 'String', required: true},
   done: {type: 'Boolean'}
 });
 var Save = mongoose.model('Save', SaveSchema);
 
 module.exports = Save;