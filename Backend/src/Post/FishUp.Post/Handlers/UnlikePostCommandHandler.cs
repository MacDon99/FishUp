﻿using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers
{
    public class UnlikePostCommandHandler : ICommandHandler<UnlikePostCommand>
    {
        private readonly PostDbContext _dbContext;

        public UnlikePostCommandHandler(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UnlikePostCommand request, CancellationToken cancellationToken)
        {
            var post = _dbContext.Posts.Include(post => post.Likers).Single(post => post.Id == request.postId);
            post.RemoveLike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
