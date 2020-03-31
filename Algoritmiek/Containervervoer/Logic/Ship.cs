using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic
{


    public class Ship
    {

        public Stack[] stacks { get; private set; }
        private readonly int maxTotalWeight;
        public readonly int xLength;
        public readonly int yLength;
        public Ship(int xLenght, int yLenght)
        {
            this.xLength = xLenght;
            this.yLength = yLenght;
            stacks = new Stack[xLenght * yLenght];
            for (int x = 0; x < xLenght; x++)
            {
                for (int y = 0; y < yLenght; y++)
                {
                    stacks[xLenght * y + x] = new Stack(x, y);
                }
            }
            maxTotalWeight = 150000 * stacks.Length;
        }

        private bool LeftIsHeviest()
        {
            return LeftWeight() > RightWeight();
        }

        private int LeftWeight()
        {
            int weight = 0;
            for (int y = 0; y < yLength; y++)
            {
                for (int left = 0; left < xLength / 2; left++)
                {
                    weight += GetStack(left, y).Weight();
                }
            }
            return weight;
        }
        private int RightWeight()
        {
            int weight = 0;
            for (int y = 0; y < yLength; y++)
            {
                for (int right = xLength / 2; right < xLength; right++)
                {
                    weight += GetStack(right, y).Weight();
                }
            }
            return weight;
        }
        private int TotalWeight()
        {
            int weight = 0;
            foreach (Stack stack in stacks)
            {
                weight += stack.Weight();
            }
            return weight;
        }

        public void AddAndDistribute(List<Container> containers)
        {
            foreach (Container container in containers)
            {
                if (container.cooled && container.valuable)
                {
                    
                    int y = 0;
                    for (int x = 0; x < xLength; x++)
                    {
                        if (!GetStack(x, y).hasValuable())
                        {
                            GetStack(x, y).AddContainer(container, true);
                        }
                    }
                    //sjskldjfkl;
                }
                for (int y = 0; y < yLength; y++)
                {
                    for (int x = 0; x < xLength; x++)
                    {

                    }
                }
            }
        }
        public void lol()
        {/*  public void AddContainers(List<Container> containers)
          {
              for (int container = 0; container < containers.Count; container++)
              {
                  findStack(containers[container]);
              }
          }

          private bool findStack(Container container)
          {
              int beginPoint = LeftIsHeviest() ? xLenght / 2 : 0;
              int endPoint = LeftIsHeviest() ? xLenght : xLenght / 2;
              for (int y = 0; y < yLenght; y++)
              {
                  {/* if (LeftIsHeviest())
                  {
                      for (int x = xLenght - 1; x > xLenght / 2-1; x--)
                      {
                          if (GetStack(x, y).AddContainer(container))
                          {
                              return true;
                          }
                      }

                  }
                  else
                  {
                      for (int x = 0; x < xLenght / 2; x++)
                      {
                          if (GetStack(x, y).AddContainer(container))
                          {
                              return true;
                          }
                      }
                  }
                  }
                  for (int x = beginPoint; x < endPoint; x++)
                  {
                      Stack stack = GetStack(x, y);
                      if (container.cooled && y != 0)
                      {
                          return false;
                      }
                      if (stack.stack.Count > 0)
                      {
                          if ((stack.Weight() - stack.stack[stack.stack.Count - 1].weight) + container.weight > 120000)
                          {
                              return false;
                          }
                      }
                      if (container.valuable)
                      {
                          if (y % 2 == 0)
                          {
                              if (stack.hasValuable())
                              {
                                  return false;
                              }
                              stack.stack.Insert(0, container);
                              return true;
                          }
                          else
                          {
                              return false;
                          }
                      }
                      stack.stack.Add(container);
                      return true;
                  }
              }
              return false;
          }*/
        }

        public Stack GetStack(int x, int y)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.x == x && stack.y == y)
                {
                    return stack;
                }
            }
            return null;
        }

        public override string ToString()
        {

            float percentageLeft = (float)100 * LeftWeight() / TotalWeight();
            float percentageRight = (float)100 * RightWeight() / TotalWeight();
            float percentageOfMax = (float)100 * TotalWeight() / maxTotalWeight;
            return string.Format("Weight left: {0}Kg , {1}% \nWeight right: {2} Kg , {3}% \nWeight total: {4} Kg , {5}% of Max({6} Kg)", LeftWeight(), percentageLeft.ToString("00.000"), RightWeight(), percentageRight.ToString("00.000"), TotalWeight(), percentageOfMax.ToString("00.000"), maxTotalWeight);
        }
    }
}
