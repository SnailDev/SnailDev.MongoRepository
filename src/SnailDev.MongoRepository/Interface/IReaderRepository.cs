using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IReaderRepository<TEntity, TKey>
    {
        /// <summary>
        /// create increment ID
        /// <remarks>default increment ID saved in [Sequence] collection</remarks>
        /// </summary>
        /// <returns></returns>
        long CreateIncID(long inc = 1, int iteration = 0);

        /// <summary>
        /// create increment ID
        /// </summary>
        /// <param name="entity"></param>
        void CreateIncID(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">primary key</param>
        /// <param name="includeFieldExp"></param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="hint">hint index</param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        TEntity Get(TKey id, Expression<Func<TEntity, object>> includeFieldExp = null
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterExp"></param>
        /// <param name="includeFieldExp"></param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="hint">hint index</param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> filterExp, Expression<Func<TEntity, object>> includeFieldExp = null
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sort"></param>
        /// <param name="projection"></param>
        /// <param name="hint">hint index</param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        TEntity Get(FilterDefinition<TEntity> filter
            , ProjectionDefinition<TEntity, TEntity> projection = null
            , SortDefinition<TEntity> sort = null, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterExp"></param>
        /// <param name="includeFieldExp"></param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="hint">hint index</param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filterExp = null
            , Expression<Func<TEntity, object>> includeFieldExp = null
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending
            , int limit = 0, int skip = 0, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="projection"></param>
        /// <param name="sort"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="hint">hint索引</param>
        /// <param name="readPreference">访问设置</param>
        /// <returns></returns>
        List<TEntity> GetList(FilterDefinition<TEntity> filter
            , ProjectionDefinition<TEntity, TEntity> projection = null
            , SortDefinition<TEntity> sort = null
            , int limit = 0, int skip = 0, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="fieldExp"></param>
        /// <param name="filterExp"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TField> Distinct<TField>(Expression<Func<TEntity, TField>> fieldExp, Expression<Func<TEntity, bool>> filterExp
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="fieldExp"></param>
        /// <param name="filter"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TField> Distinct<TField>(Expression<Func<TEntity, TField>> fieldExp, FilterDefinition<TEntity> filter
            , ReadPreference readPreference = null);

        /// <summary>
        /// Distinct
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="filter"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TField> Distinct<TField>(FieldDefinition<TEntity, TField> field, FilterDefinition<TEntity> filter
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="hint">hint索引</param>
        /// <param name="readPreference">访问设置</param>
        /// <returns></returns>
        long Count(FilterDefinition<TEntity> filter
            , int limit = 0, int skip = 0, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterExp"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="hint">hint索引</param>
        /// <param name="readPreference">访问设置</param>
        /// <returns></returns>
        long Count(Expression<Func<TEntity, bool>> filterExp
            , int limit = 0, int skip = 0, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="hint">hint索引</param>
        /// <param name="readPreference">访问设置</param>
        /// <returns></returns>
        bool Exists(FilterDefinition<TEntity> filter, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterExp"></param>
        /// <param name="hint">hint索引</param>
        /// <param name="readPreference">访问设置</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> filterExp, BsonValue hint = null
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TID"></typeparam>
        /// <param name="filterExp"></param>
        /// <param name="id">$group -> _id</param>
        /// <param name="group">$group</param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TResult> Aggregate<TResult, TID>(Expression<Func<TEntity, bool>> filterExp
            , Expression<Func<TEntity, TID>> id, Expression<Func<IGrouping<TID, TEntity>, TResult>> group
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending
            , int limit = 0, int skip = 0
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TID"></typeparam>
        /// <param name="filter"></param>
        /// <param name="id">$group -> _id</param>
        /// <param name="group">$group</param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TResult> Aggregate<TResult, TID>(FilterDefinition<TEntity> filter
            , Expression<Func<TEntity, TID>> id, Expression<Func<IGrouping<TID, TEntity>, TResult>> group
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending
            , int limit = 0, int skip = 0
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TID"></typeparam>
        /// <param name="filterExp"></param>
        /// <param name="group"></param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TResult> Aggregate<TResult, TID>(Expression<Func<TEntity, bool>> filterExp
            , ProjectionDefinition<TEntity, TResult> group
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending
            , int limit = 0, int skip = 0
            , ReadPreference readPreference = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TID"></typeparam>
        /// <param name="filter"></param>
        /// <param name="group"></param>
        /// <param name="sortExp"></param>
        /// <param name="sortType"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <param name="readPreference"></param>
        /// <returns></returns>
        List<TResult> Aggregate<TResult, TID>(FilterDefinition<TEntity> filter
            , ProjectionDefinition<TEntity, TResult> group
            , Expression<Func<TEntity, object>> sortExp = null, SortType sortType = SortType.Ascending
            , int limit = 0, int skip = 0
            , ReadPreference readPreference = null);

    }
}
