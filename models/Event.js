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
    lobbyCode: {
        type: String,
        required: false
    },
    description: {
        type: String,
        required: true,
    },
    group: {
        type: Schema.Types.ObjectId,
        ref:'Group',
    }
})

const Event = model('Event', eventSchema);

module.exports = Event;