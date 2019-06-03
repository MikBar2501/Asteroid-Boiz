using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator.Strategy.Pleacment
{
    public class AroundScreenStrategy : ScreenBasedStrategy
    {
        protected List<Vector3> topSpots;
        protected List<Vector3> bottomSpots;
        protected List<Vector3> rightSpots;
        protected List<Vector3> leftSpots;

        public float outOfScreenOffset;
        public float spacing;

        bool top;
        bool bottom;
        bool right;
        bool left;

        public AroundScreenStrategy Set(float outOfScreenOffset, float spacing, bool top, bool bottom, bool right, bool left)
        {
            this.outOfScreenOffset = outOfScreenOffset;
            this.spacing = spacing;
            this.top = top;
            this.bottom = bottom;
            this.right = right;
            this.left = left;
            return this;
        }

        public override void Arrange(GameObject[] objects)
        {
            base.Arrange(objects);
            MakeSpots();
        }

        protected void MakeSpots()
        {
            topSpots = new List<Vector3>();
            bottomSpots = new List<Vector3>();
            rightSpots = new List<Vector3>();
            leftSpots = new List<Vector3>();

            for(float stepX = area.screenLeft + spacing; stepX < area.screenRight; stepX += spacing)
            {
                if(top)
                topSpots.Add(new Vector3(stepX, area.screenTop + outOfScreenOffset));
                if(bottom)
                bottomSpots.Add(new Vector3(stepX, area.screenBottom - outOfScreenOffset));
            }

            for (float stepY = area.screenBottom + spacing; stepY < area.screenTop; stepY += spacing)
            {
                if(right)
                rightSpots.Add(new Vector3(area.screenRight + outOfScreenOffset, stepY));
                if(left)
                leftSpots.Add(new Vector3(area.screenLeft - outOfScreenOffset, stepY));
            }
        }
    }
}
