using System;
using System.Collections.Generic;
using Tripod.Core;

namespace Archive.API.Model
{
  /// <summary>
  /// 店组
  /// </summary>
  public class BranchGroup: RecordEntity
  {
    /// <summary>
    /// 自增编码
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 是否为私有(仅创建用户可见)
    /// </summary>
    public bool IsPrivate { get; set; }

    /// <summary>
    /// 机构组机构关系
    /// </summary>
    public IList<BranchGroupBranch> BranchGroupBranches { get; set; }
  }
}