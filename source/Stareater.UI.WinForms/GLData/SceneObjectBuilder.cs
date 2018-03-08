﻿using OpenTK;
using Stareater.GraphicsEngine;
using System.Collections.Generic;
using System;
using Stareater.GLData.SpriteShader;
using System.Drawing;

namespace Stareater.GLData
{
	class SceneObjectBuilder
	{
		private List<PolygonData> polygons = new List<PolygonData>();
		private PhysicalData physicalShape = null;
		private object data = null;

		private PolygonType currentPolygonType = PolygonType.None;
		private float z;
		private List<float> vertexData = new List<float>();

		#region Sprite data
		private int textureId;
		private Color color;
		private Matrix4 localTransform = Matrix4.Identity;
		#endregion

		public SceneObjectBuilder()
		{ }

		public SceneObjectBuilder(object data, Vector2 center, float size)
		{
			this.data = data;
			this.physicalShape = new PhysicalData(center, new Vector2(size));
		}

		public SceneObject Build()
		{
			this.applyPolygonData();
			return new SceneObject(polygons, physicalShape, data);
		}

		#region Builder methods
		public SceneObjectBuilder StartSprite(float z, int textureId, Color color)
		{
			this.applyPolygonData();
			
			this.currentPolygonType = PolygonType.Sprite;
			this.z = z;
			this.textureId = textureId;
			this.color = color;

			return this;
		}

		public SceneObjectBuilder AddVertices(IEnumerable<float> vertexData)
		{
			this.assertStarted();

			this.vertexData.AddRange(vertexData);

			return this;
		}

		public SceneObjectBuilder AddVertices(IEnumerable<Vector2> vertices)
		{
			this.assertStarted();

			foreach(var v in vertices)
			{
				this.vertexData.Add(v.X);
				this.vertexData.Add(v.Y);
			}

			return this;
		}

		public SceneObjectBuilder StartSimpleSprite(float z, TextureInfo sprite, Color color)
		{
			this.applyPolygonData();

			this.currentPolygonType = PolygonType.Sprite;
			this.z = z;
			this.vertexData.AddRange(SpriteHelpers.UnitRectVertexData(sprite));
			this.textureId = sprite.Id;
			this.color = color;

			return this;
		}

		public SceneObjectBuilder Scale(float scale)
		{
			this.assertStarted();

			this.localTransform *= Matrix4.CreateScale(scale, scale, 1);

			return this;
		}

		public SceneObjectBuilder Scale(float scaleX, float scaleY)
		{
			this.assertStarted();

			this.localTransform *= Matrix4.CreateScale(scaleX, scaleY, 1);

			return this;
		}

		public SceneObjectBuilder Translate(double x, double y)
		{
			this.assertStarted();

			this.localTransform *= Matrix4.CreateTranslation((float)x, (float)y, 0);

			return this;
		}

		public SceneObjectBuilder Translate(Vector2 offset)
		{
			this.assertStarted();

			this.localTransform *= Matrix4.CreateTranslation(offset.X, offset.Y, 0);

			return this;
		}

		public SceneObjectBuilder Transform(Matrix4 transform)
		{
			this.assertStarted();

			this.localTransform *= transform;

			return this;
		}
		#endregion

		private void applyPolygonData()
		{
			if (this.currentPolygonType == PolygonType.None)
				return;

			IShaderData shaderData = null;

			if (this.currentPolygonType == PolygonType.Sprite)
				shaderData = new SpriteData(this.localTransform, this.textureId, this.color);
			else
				throw new NotImplementedException(this.currentPolygonType.ToString());

			this.polygons.Add(new PolygonData(this.z, shaderData, this.vertexData));
			
			//clean up
			this.vertexData = new List<float>();
			this.localTransform = Matrix4.Identity;
		}

		private void assertStarted()
		{
			if (this.currentPolygonType == PolygonType.None)
				throw new InvalidOperationException("Polygon data not started");
		}

		private enum PolygonType
		{
			None,
			Orbit,
			Sprite
		}
	}
}