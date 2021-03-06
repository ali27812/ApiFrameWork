﻿using AutoMapper.QueryableExtensions;
using Data.Contracts;
using Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Filters;

namespace WebFramework.Api
{
    [ApiController]
    [AllowAnonymous]
    [ApiResultFilter]
    [Route("api/[controller]")]
    public class CrudController<TDto, TSelectDto, TEntity, TKey> : ControllerBase
         where TDto : BaseDto<TDto, TEntity, TKey>, new()
         where TSelectDto : BaseDto<TSelectDto, TEntity, TKey>, new()
         where TEntity : BaseEntity<TKey>, new()
    {
        private readonly IRepository<TEntity> _repository;

        public CrudController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await _repository.TableNoTracking.ProjectTo<TSelectDto>()
                .ToListAsync(cancellationToken);

            return Ok(list);
        }

        [HttpGet("{id:guid}")]
        public async Task<ApiResult<TSelectDto>> Get(TKey id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<TSelectDto>()
                .SingleOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);

            if (dto == null)
                return NotFound();

            return dto;
        }

        [HttpPost]
        public async Task<ApiResult<TSelectDto>> Create(TDto dto, CancellationToken cancellationToken)
        {
            var model = dto.ToEntity();

            await _repository.AddAsync(model, cancellationToken);

            var resultDto = await _repository.TableNoTracking.ProjectTo<TSelectDto>().SingleOrDefaultAsync(p => p.Id.Equals(model.Id), cancellationToken);

            return resultDto;
        }

        [HttpPut]
        public async Task<ApiResult<TSelectDto>> Update(TKey id, TDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);

            model = dto.ToEntity(model);

            await _repository.UpdateAsync(model, cancellationToken);

            var resultDto = await _repository.TableNoTracking.ProjectTo<TSelectDto>().SingleOrDefaultAsync(p => p.Id.Equals(model.Id), cancellationToken);

            return resultDto;
        }

        [HttpDelete("{id:guid}")]
        public async Task<ApiResult> Delete(TKey id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);

            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }




    public class CrudController<TDto, TSelectDto, TEntity> : CrudController<TDto, TSelectDto, TEntity, int>
        where TDto : BaseDto<TDto, TEntity, int>, new()
        where TSelectDto : BaseDto<TSelectDto, TEntity, int>, new()
        where TEntity : BaseEntity<int>, new()
    {
        public CrudController(IRepository<TEntity> repository)
            : base(repository)
        {
        }
    }

    public class CrudController<TDto, TEntity> : CrudController<TDto, TDto, TEntity, int>
       where TDto : BaseDto<TDto, TEntity, int>, new()
       where TEntity : BaseEntity<int>, new()
    {
        public CrudController(IRepository<TEntity> repository)
            : base(repository)
        {
        }
    }

}
