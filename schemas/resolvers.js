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
        lastName,
        gender,
        photo,
        bio,
        birthdate,
        currentCity,
        platforms,
        user,
      },
      context
    ) => {
      if (context.user) {
        const profile = await Profile.create({
          firstName,
          lastName,
          gender,
          photo,
          bio,
          birthdate,
          currentCity,
          platforms,
          user,
        });
        return profile;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // update user's Profile
    updateProfile: async (parent, args, context) => {
      if (context.user) {
        return await Profile.findOneAndUpdate(
          { _id: args.profileId },
          {
            $set: {
              firstName: args.firstName,
              lastName: args.lastName,
              gender: args.gender,
              photo: args.photo,
              bio: args.bio,
              birthdate: args.birthdate,
              currentCity: args.currentCity,
              platforms: args.platforms,
            },
          },
          { new: true }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // deletes user's profile
    removeProfile: async (parent, { profileId }, context) => {
      if (context.user) {
        const deletedProfile = await Profile.findOneAndDelete(
          { _id: profileId }
        );
        return deletedProfile;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // add a group
    addGroup: async (
      parent,
      { 
        groupName, 
        description, 
        event, 
        profile, 
        user,
      },
      context
    ) => {
      if (context.user) {
        const group = await Group.create({
          groupName, 
          description, 
          event, 
          profile, 
          user,
        });
        return group;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // updateGroup
    updateGroup: async (parent, args, context) => {
      if (context.user) {
        return await Group.findOneAndUpdate(
          { _id: args.groupId },
          {
            $set: {
              groupName: args.groupName, 
              description: args.description, 
            },
          },
          { new: true }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // delete a group by the id
    removeGroup: async (parent, { groupId }, context) => {
      if (context.user) {
        const deletedGroup = await Group.findOneAndDelete(
          { _id: groupId }
        );
        return deletedGroup;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // add an event
    addEvent: async (
      parent,
      {
        eventName, 
        eventDate, 
        lobbyCode, 
        description, 
        group, 
        profile, 
        user, 
      },
      context
    ) => {
      if (context.user) {
        const event = await Event.create({
          eventName, 
          eventDate, 
          lobbyCode, 
          description, 
          group, 
          profile, 
          user,
        });
        return event;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // update an event
    updateEvent: async (parent, args, context) => {
      if (context.user) {
        return await Event.findOneAndUpdate(
          { _id: args.eventId },
          {
            $set: {
              eventName: args.eventName, 
              eventDate: args.eventDate, 
              lobbyCode: args.lobbyCode, 
              description: args.description,  
            },
          },
          { new: true }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // delete an event by id (look at activity 12 resolvers)
    removeEvent: async (parent, { eventId }, context) => {
      if (context.user) {
        return Event.findOneAndDelete(
          { _id: eventId }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // add a post
    addPost: async (parent, {
      title,
      content,
      date,
      user,
    }, 
    context
    ) => {
      if (context.user) {
        const post = await Post.create({
          title,
          content,
          date,
          user,
        });
        return post;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // update a post
    updatePost: async (parent, args, context) => {
      if (context.user) {
        return await Post.findOneAndUpdate(
          { _id: args.postId },
          {
            $set: {
              title: args.title, 
              content: args.content,  
            },
          },
          { new: true }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // remove a post
    removePost: async (parent, { postId }, context) => {
      if (context.user) {
        return Post.findOneAndDelete(
          { _id: postId }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // add a comment
    addComment: async (parent, {
      comment,
      commentDate,
      post,
      user,
    },
    context
    ) => {
      if (context.user) {
        const comment = await Comment.create(
          {
            comment,
            commentDate,
            post,
            user,
          }
        );
        return comment;
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    // update a comment
    updateComment: async (parent, args, context) => {
      if (context.user) {
        return await Comment.findOneAndUpdate(
          { _id: args.commentId },
          {
            $set: {
              comment: args.comment,  
            },
          },
          { new: true }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

    removeComment: async (parent, { commentId }, context) => {
      if (context.user) {
        return Comment.findOneAndDelete(
          { _id: commentId }
        );
      }
      throw new AuthenticationError("You need to be logged in!");
    },

  },
};

module.exports = resolvers;