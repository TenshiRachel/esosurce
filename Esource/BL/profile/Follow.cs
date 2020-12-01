using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esource.DAL.profile;

namespace Esource.BL.profile
{
    public class Follow
    {
        public int followerId { get; set; }
        public int followingId { get; set; }

        public Follow()
        {

        }

        public Follow(int followerId, int followingId)
        {
            this.followerId = followerId;
            this.followingId = followingId;
        }

        public int Insert()
        {
            int result = new FollowDAO().AddFollow(this);
            return result;
        }

        public int Remove(string followerId, string followingId)
        {
            int result = new FollowDAO().RemoveFollow(followerId, followingId);
            return result;
        }

        public bool isFollowed(string followerId, string followingId)
        {
            bool followed = new FollowDAO().isFollowed(followerId, followingId);
            return followed;
        }
    }
}