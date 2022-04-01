const { AuthenticationError } = require("apollo-server-express");
const { Comment, Post, Event, Group, Profile, User } = require("../models");
const { signToken } = require("../utils/auth");

const resolvers = {
  Query: {
    // get all users
    users: async () => {
      return User.find().populate("profile");
    },
    // get one user by id for signup, so user id can be added to profile schema
    user: async (parent, args) => {
      return await User.findById(args.id).populate("profile");
    },
    // get all profiles
    profiles: async () => {
      return Profile.find({}).populate("user");
    },
    // get one profile by id. this is for the dashboard
    profile: async (parent, args) => {
      return Profile.findById(args.id).populate("user");
    },
    // get the profile of the user that is logged in 
    userprofile: async(parent, args) =>{
      return Profile.findOne(args).populate("user");
    },
    // get all groups
    groupsTest: async () => {
      return Group.find({})
        .populate("event")
        .populate("profile")
        .populate("user");
    },
    // get all the groups
    groups: async () => {
      return Group.find({})
        .populate("event")
        .populate("profile")
        .populate("user");
    },
    // get all the groups for one user by the user's id
    group: async (parent, args) => {
      return Group.find(args.id)
        .populate("event")
        .populate("profile")
        .populate("user");
    },
    // get all the events
    eventTest: async (parent, args) => {
      return Event.find(args)
        .populate("group")
        .populate("profile")
        .populate("user");
    },
    // get all the events
    events: async (parent, args) => {
      return Event.find({})
      .populate("group")
      .populate("profile")
      .populate("user");
    },
    // get one event by id (also might need to query for user's id that is logged in)
    event: async (parent, args) => {
      return Event.findById(args)
        .populate("group")
        .populate("profile")
        .populate("user");
    },
    // get all posts
    postTest: async () => {
      return Post.find({}).populate("user").populate("comments");
    },
    // get all posts for a user
    posts: async (parent, args) => {
      return Post.find(args).populate("user").populate("comments");
    },
    // get all posts from an event
    posts: async (parent, args) => {
      return Post.find(args).populate("user").populate("comments");
    },
    // get a single post
    post: async (parent, args) => {
      return Post.find(args).populate("user").populate("comments");
    },
    comments: async (parent, args) => {
      return Comment.find(args).populate("post").populate("user");
    },
    // By adding context to our query, we can retrieve the logged in user without specifically searching for them
    me: async (parent, args, context) => {
      if (context.user) {
        return User.findOne({ _id: context.user._id }).populate("profile");
      }
      throw newAuthenticationError("You need to be logged in!");
    },
  },
  Mutation: {
    // update - login
    login: async (parent, { email, password }) => {
      const user = await User.findOne({ email });

      if (!user) {
        throw new AuthenticationError(
          "Incorrect email or password! Try again QUEEN"
        );
      }

      const correctPw = await user.isCorrectPassword(password);

      if (!correctPw) {
        throw new AuthenticationError(
          "Incorrect email or password! Try again QUEEN"
        );
      }

      const token = signToken(user);
      return { token, user };
    },
    // create a new user
    addUser: async (parent, { email, password }) => {
      const user = await User.create({ email, password });
      const token = signToken(user);

      return { token, user };
    },
    // update a user to add the profile ID
    updateUser: async (parent, args, context)=>{
      if(context.user){
        return await User.findOneAndUpdate(
          {_id:args.id},
          {$set:{profile:args.profile}},
          {new:true}
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },
    // create a new profile
    addProfile: async (
      parent,
      {
        firstName,
        photo,
        attachmentStyle,
        genderIdentity,
        genderInterests,
        bio,
        birthdate,
        pronouns,
        sexualOrientation,
        currentCity,
        user,
      },
      context
    ) => {
      if (context.user) {
        const profile = await Profile.create(
          {
            firstName,
            photo,
            attachmentStyle,
            genderIdentity,
            genderInterests,
            bio,
            birthdate,
            pronouns,
            sexualOrientation,
            currentCity,
            user,
          }
        );
        return profile;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // updateProfile: async
    updateProfile: async (parent, args, context) => {
      if (context.user) {
        return await Profile.findOneAndUpdate(
          { _id: args.profileId },
          {
            $set: {
              firstName: args.firstName,
              photo: args.photo,
              attachmentStyle: args.attachmentStyle,
              genderIdentity: args.genderIdentity,
              genderInterests: args.genderInterests,
              bio: args.bio,
              birthdate: args.birthdate,
              pronouns: args.pronouns,
              sexualOrientation: args.sexualOrientation,
              currentCity: args.currentCity,
            },
          },
          { new: true }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // add a thread
    addThread: async (
      parent,
      { text, user, match,},
      context
    ) => {
      if (context.user) {
        const thread = await Thread.create({
          text,
          user,
          match,
        })
        return thread;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // delete a thread by the id
    removeThread: async (parent, { threadId }, context) => {
      if (context.user) {
        const deleteThread = await Thread.findOneAndDelete(
          { _id: threadId }
        );
        return deleteThread;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // add a message
    addMessage: async (
      parent,
      {text, date, thread, user },
      context
    ) => {
      if (context.user) {
        const message = await Message.create({
          text,
          date,
          thread,
          user,
        });
        return message;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // delete a message by id look at activity 12 resolvers
    removeMessage: async (parent, { messageId }, context) => {
      if (context.user) {
        return Message.findOneAndDelete(
          { _id: messageId }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },
  },
};

module.exports = resolvers;