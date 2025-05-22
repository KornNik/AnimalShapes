using System.Collections.Generic;
using UnityEngine;
using Behaviours;

namespace Helpers.Extensions
{
	class SpawnExtender
	{
		/// <summary>
		/// Makes a square formation around the vector (0, 0, 0), favoring width over depth.
		/// </summary>
		/// <param name="obj">The GameObject that is being spawned.</param>
		/// <param name="groupSize">The size of the group.</param>
		/// <returns>Returns an array of positions that is made from the parameters given.</returns>
		public static List<Vector2> MakeFormation(Collider2D collider, int groupSize)
		{
			List<Vector2> positions = new List<Vector2>();

			int width = Mathf.CeilToInt(Mathf.Sqrt(groupSize));
			int depth = Mathf.CeilToInt((float)groupSize / (float)width);

			float spreadWidth = collider.bounds.size.x * 1f;
			float spreadDepth = collider.bounds.size.y * 0.8f;

			// Simple calculation take width = 2 & spreadWidth = 1:
			// 2 - 1 = 1
			// 1 / -2f = -0.5
			// -0.5 * 1 = -0.5
			// each x or z the spread will be added so the middle of the square is always (0, 0, 0).
			float bottomLeftX = ((width - 1) / -2f) * spreadWidth;
			float bottomLeftY = ((depth - 1) / -2f) * spreadDepth;

			// Loop through the depth and rows and make the positions
			for (float x = 0; x < depth; x++)
			{
				for (float y = 0; y < width; y++)
				{
					// Add the (x * spread) and (y * spread) to their start positions
					positions.Add(new Vector2(bottomLeftX + (y * spreadWidth), bottomLeftY + (x * spreadDepth)));
				}
			}

			return positions;
		}
	}
}
