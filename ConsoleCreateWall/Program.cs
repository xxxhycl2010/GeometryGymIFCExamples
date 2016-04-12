﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryGym.Ifc;

namespace ConsoleCreateWall
{
	class Program
	{
		static void Main(string[] args)
		{
			DatabaseIfc db = new DatabaseIfc(ModelView.Ifc4DesignTransfer);
			IfcBuilding building = new IfcBuilding(db, "IfcBuilding") {  };
			IfcProject project = new IfcProject(building, "IfcProject",IfcUnitAssignment.Length.Millimetre) { };

			//IfcBuildingStorey storey = new IfcBuildingStorey(building, "Ground Floor", 0);
			IfcMaterial masonryFinish = new IfcMaterial(db, "Masonry - Brick - Brown");
			IfcMaterial masonry = new IfcMaterial(db, "Masonry");
			IfcMaterialLayer layerFinish = new IfcMaterialLayer(masonryFinish, 110, "Finish");
			IfcMaterialLayer airInfiltrationBarrier = new IfcMaterialLayer(db, 50, "Air Infiltration Barrier") { IsVentilated = IfcLogicalEnum.TRUE };
			IfcMaterialLayer structure = new IfcMaterialLayer(masonry, 110, "Core");
			string name = "Double Brick - 270";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet(new List<IfcMaterialLayer>() { layerFinish, airInfiltrationBarrier, structure }, name);
			db.NextObjectRecord = 300;
			IfcWallType wallType = new IfcWallType(name, materialLayerSet, IfcWallTypeEnum.NOTDEFINED) {  };
			// todo implement rhinocommon overload IfcWallStandardCase wallStandardCase = new IfcWallStandardCase(building, wallType, new Line(0, 0, 0, 5000, 0, 0), 2000, 0, true, null) {  };

		}
	}
}
