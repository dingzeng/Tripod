using System;

namespace Archive.API.ViewModel
{
    /// <summary>
    /// 商品类别模型
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <value></value>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 父类别Id
        /// </summary>
        /// <value></value>
        public string ParentId { get; set; }

        /// <summary>
        /// 父类别名称
        /// </summary>
        /// <value></value>
        public string ParentName { get; set; }
    }
}