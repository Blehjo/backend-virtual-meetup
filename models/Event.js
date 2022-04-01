const { Schema, model } = require('mongoose');

const eventSchema = new Schema({
    eventName: {
        type: String,
        required: true,
        trim: true,
    },
    eventDate: {
        type: Date,
        required: true,
    },
    description: {
        type: String,
        required: true,
    },
    group: {
        type:Schema.Types.ObjectId,
        ref:'Group',
    }
})

const Group = model('Group', groupSchema);

module.exports = Group;