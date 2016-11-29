﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stareater.GLData;
using OpenTK;

namespace Stareater.GLRenderers
{
	class BatchDrawable<TChild, TData> : IDrawable where TChild : IDrawable
	{
		private VertexArray vao = null;
		private AGlProgram forProgram;
		private Func<VertexArray, int, TData, TChild> childFactory;
		private List<TChild> subdrawables = new List<TChild>();

		public BatchDrawable(AGlProgram forProgram, Func<VertexArray, int, TData, TChild> childFactory)
		{
			this.childFactory = childFactory;
			this.forProgram = forProgram;
		}

		public void Draw(Matrix4 view)
		{
			foreach (var child in subdrawables)
				child.Draw(view);
		}

		public void Update(VertexArrayBuilder vaoBuilder, IList<TData> childData)
		{
			if (this.vao == null)
			{
				this.subdrawables = new List<TChild>();
				this.vao = vaoBuilder.Generate(forProgram);
			}
			else
			{
				vaoBuilder.Update(this.vao);
				this.subdrawables.Clear();
			}

			for (int i = 0; i < childData.Count; i++)
				this.subdrawables.Add(childFactory(this.vao, i, childData[i]));
		}
	}
}
