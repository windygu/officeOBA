﻿using System;
using System.Collections.Generic;

namespace Cooperativeness.OBA.Word.Ribbon.Model
{
    /// <summary>
    /// 定义子元素集合对象
    /// </summary>
    internal class ChildRibbonElements : ElementCollection
    {
        #region 字段
        private RibbonElement _container;

        #endregion

        #region 构造函数
        public ChildRibbonElements(RibbonElement container)
        {
            this._container = container;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<RibbonElement> GetEnumerator()
        {
            if (!this._container.HasChildren || (this._container.FirstChild == null))
                goto labl_ret;
            RibbonElement firstChild = this._container.FirstChild;
            while (firstChild != null)
            {
                yield return firstChild;
                firstChild = firstChild.NextSibling();
            }
            labl_ret: ;
        }

        /// <summary>
        /// 根据下标获取元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override RibbonElement GetItem(int index)
        {
            if (this._container.HasChildren)
            {
                for (RibbonElement element = this._container.FirstChild; element != null; element = element.NextSibling())
                {
                    if (index == 0)
                    {
                        return element;
                    }
                    index--;
                }
            }
            throw new ArgumentOutOfRangeException("index");
        }

        #endregion

        #region 属性
        /// <summary>
        /// 获取当前元素的个数
        /// </summary>
        public override int Count
        {
            get
            {
                int num = 0;
                if (this._container.HasChildren)
                {
                    for (RibbonElement element = this._container.FirstChild; element != null; element = element.NextSibling())
                    {
                        num++;
                    }
                }
                return num;
            }
        }
        #endregion
    }
}