using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;
    public int wood;
    public int stone;
    public int wheat;
    public float[] originalVertices;
    public float[] vertices;
    public float[] postition;
    public string[] treeNames;
    public string[] rockNames;
    public float[] treePostition;
    public float[] treeRotation;
    public float[] rockPostition;
    public float[] rockRotation;
    public float[] rotation;
    public string[] buildingNames;
    public int[] numberOfResidents;
    public int[] numberOfMaxResidents;
    public int[] numberOfFarmers;
    public int[] numberOfLumberJacks;
    public int[] numberOfMiners;
    public int[] numberOfWheat;
    public int[] numberOfWood;
    public int[] numberOfStone;
    public float[] numberOfJobs;
    public float[] vertexPoints;
    public int numberOfChildren;
    public int numberOfTrees;
    public int numberOfRocks;
    public int getNumberOfResidents;
    public int getNumberOfMaxResidents;
    public int getNumberOfFarmers;
    public int getNumberOfWheat;
    public int getNumberOfLumberJacks;
    public int getNumberOfWood;
    public int getNumberOfMiners;
    public int getNumberOfStone;
    public string townName;
    public bool oneOriginalVertices;
    public int seed;
    public int numberOfDays;
    public float timeOfDay;

    public PlayerData(GetData items)
    {
        int i2 = 0;
        int i3 = 0;
        int i4 = 0;
        int i5 = 0;
        int i6 = 0;
        int i7 = 0;

        int num = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;

        postition = new float[items.getPosition().Length * 3];
        vertices = new float[items.getVertices().Length * 3];
        originalVertices = new float[items.getOriginalVertices().Length * 3];
        treeNames = new string[items.getTreeName().Length];
        rockNames = new string[items.getRockName().Length];
        treePostition = new float[items.getTreePos().Length * 3];
        treeRotation = new float[items.getTreeRos().Length * 4];
        rockPostition = new float[items.getRockPos().Length * 3];
        rockRotation = new float[items.getRockRos().Length * 4];
        rotation = new float[items.getRotation().Length * 4];
        buildingNames = new string[items.getPosition().Length];
        numberOfResidents = new int[items.getResidents().Length];
        numberOfMaxResidents = new int[items.getMaxResidents().Length];
        numberOfFarmers = new int[items.getFarmers().Length];
        numberOfLumberJacks = new int[items.getLumberJacks().Length];
        numberOfMiners = new int[items.getMiners().Length];
        numberOfWheat = new int[items.getWheatValue().Length];
        numberOfWood = new int[items.getWoodValue().Length];
        numberOfStone = new int[items.getStoneValue().Length];
        numberOfJobs = new float[items.GetJobHome().Length * 3];
        vertexPoints = new float[items.getVertexPoints().Length * 3];

        numberOfChildren = items.children;
        numberOfTrees = items.tree;
        numberOfRocks = items.rock;
        getNumberOfResidents = items.numberOfResidents.Length;
        getNumberOfMaxResidents = items.numberOfMaxResidents.Length;
        getNumberOfFarmers = items.numberOfFarmers.Length;
        getNumberOfWheat = items.numberOfWheat.Length;
        getNumberOfLumberJacks = items.numberOfLumberJacks.Length;
        getNumberOfWood = items.numberOfWood.Length;
        getNumberOfMiners = items.numberOfMiners.Length;
        getNumberOfStone = items.numberOfStone.Length;
        oneOriginalVertices = items.oneOriginalVertices;

        money = items.moneyCalc;
        wood = items.woodCalc;
        stone = items.stoneCalc;
        wheat = items.wheatCalc;
        townName = items.townName;
        seed = items.seed;
        numberOfDays = items.numberOfDays;
        timeOfDay = items.timeOfDay;

        items.getOriginalVertices();
        for (int i = 0; i < items.getOriginalVertices().Length * 3; i++)
        {
            originalVertices[i] = items.getOriginalVertices()[num2].x;
            originalVertices[i + 1] = items.getOriginalVertices()[num2].y;
            originalVertices[i + 2] = items.getOriginalVertices()[num2].z;
            num2++;
            i += 2;
        }

        items.getVertices();
        for (int i = 0; i < items.getVertices().Length * 3; i++)
        {
            vertices[i] = items.getVertices()[num].x;
            vertices[i + 1] = items.getVertices()[num].y;
            vertices[i + 2] = items.getVertices()[num].z;
            num++;
            i += 2;
        }

        items.getBuildings();
        for (int i = 0; i < items.getBuildings().Length; i++)
        {
            buildingNames[i] = items.getBuildings()[i];
        }

        items.getPosition();
        for (int i = 0; i < items.getPosition().Length; i++)
        {
            postition[i2] = items.getPosition()[i].x;
            postition[i2 + 1] = items.getPosition()[i].y;
            postition[i2 + 2] = items.getPosition()[i].z;
            i2 += 3;
        }

        items.GetJobHome();
        for (int i = 0; i < items.GetJobHome().Length * 3; i++)
        {
            numberOfJobs[i] = items.GetJobHome()[num3].x;
            numberOfJobs[i + 1] = items.GetJobHome()[num3].y;
            numberOfJobs[i + 2] = items.GetJobHome()[num3].z;
            num3++;
            i += 2;
        }

        items.getVertexPoints();
        for (int i = 0; i < items.getVertexPoints().Length * 3; i++)
        {
            vertexPoints[i] = items.getVertexPoints()[num4].x;
            vertexPoints[i + 1] = items.getVertexPoints()[num4].y;
            vertexPoints[i + 2] = items.getVertexPoints()[num4].z;
            num3++;
            i += 2;
        }

        items.getTreePos();
        for (int i = 0; i < items.getTreePos().Length; i++)
        {
            treePostition[i4] = items.getTreePos()[i].x;
            treePostition[i4 + 1] = items.getTreePos()[i].y;
            treePostition[i4 + 2] = items.getTreePos()[i].z;
            i4 += 3;
        }

        items.getTreeName();
        for (int i = 0; i < items.getTreeName().Length; i++)
        {
            treeNames[i] = items.getTreeName()[i];
        }

        items.getRockName();
        for (int i = 0; i < items.getRockName().Length; i++)
        {
            rockNames[i] = items.getRockName()[i];
        }

        items.getTreeRos();
        for (int i = 0; i < items.getTreeRos().Length; i++)
        {
            treeRotation[i5] = items.getTreeRos()[i].x;
            treeRotation[i5 + 1] = items.getTreeRos()[i].y;
            treeRotation[i5 + 2] = items.getTreeRos()[i].z;
            treeRotation[i5 + 3] = items.getTreeRos()[i].w;
            i5 += 4;
        }

        items.getRockPos();
        for (int i = 0; i < items.getRockPos().Length; i++)
        {
            rockPostition[i6] = items.getRockPos()[i].x;
            rockPostition[i6 + 1] = items.getRockPos()[i].y;
            rockPostition[i6 + 2] = items.getRockPos()[i].z;
            i6 += 3;
        }

        items.getRockRos();
        for (int i = 0; i < items.getRockRos().Length; i++)
        {
            rockRotation[i7] = items.getRockRos()[i].x;
            rockRotation[i7 + 1] = items.getRockRos()[i].y;
            rockRotation[i7 + 2] = items.getRockRos()[i].z;
            rockRotation[i7 + 3] = items.getRockRos()[i].w;
            i7 += 4;
        }

        items.getRotation();
        for (int i = 0; i < items.getRotation().Length; i++)
        {
            rotation[i3] = items.getRotation()[i].x;
            rotation[i3 + 1] = items.getRotation()[i].y;
            rotation[i3 + 2] = items.getRotation()[i].z;
            rotation[i3 + 3] = items.getRotation()[i].w;
            i3 += 4;
        }

        items.getResidents();
        for (int i = 0; i < items.getResidents().Length; i++)
        {
            numberOfResidents[i] = items.getResidents()[i];
        }

        items.getMaxResidents();
        for (int i = 0; i < items.getMaxResidents().Length; i++)
        {
            numberOfMaxResidents[i] = items.getMaxResidents()[i];
        }

        items.getFarmers();
        for (int i = 0; i < items.getFarmers().Length; i++)
        {
            numberOfFarmers[i] = items.getFarmers()[i];
        }

        items.getLumberJacks();
        for (int i = 0; i < items.getLumberJacks().Length; i++)
        {
            numberOfLumberJacks[i] = items.getLumberJacks()[i];
        }

        items.getMiners();
        for (int i = 0; i < items.getMiners().Length; i++)
        {
            numberOfMiners[i] = items.getMiners()[i];
        }

        items.getWheatValue();
        for (int i = 0; i < items.getWheatValue().Length; i++)
        {
            numberOfWheat[i] = items.getWheatValue()[i];
        }

        items.getWoodValue();
        for (int i = 0; i < items.getWoodValue().Length; i++)
        {
            numberOfWood[i] = items.getWoodValue()[i];
        }

        items.getStoneValue();
        for (int i = 0; i < items.getStoneValue().Length; i++)
        {
            numberOfStone[i] = items.getStoneValue()[i];
        }

        items.getStoneValue();
        for (int i = 0; i < items.getStoneValue().Length; i++)
        {
            numberOfStone[i] = items.getStoneValue()[i];
        }
    }
}
