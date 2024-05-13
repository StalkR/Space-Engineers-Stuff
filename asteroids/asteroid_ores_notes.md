https://github.com/KeenSoftwareHouse/SpaceEngineers/blob/master/Sources/Sandbox.Game/Game/World/Generator/MyProceduralAsteroidCellGenerator.cs#L182

Sandbox.Game.World.Generator::MyProceduralAsteroidCellGenerator
  public override void GenerateObjects(List<MyObjectSeed> objectsList, HashSet<MyObjectSeedParams> existingObjectsSeeds)
    case MyObjectSeedType.Asteroid:
      var provider = MyCompositeShapeProvider.CreateAsteroidShape(objectSeed.Params.Seed, objectSeed.Size, MySession.Static.Settings.VoxelGeneratorVersion);

https://github.com/KeenSoftwareHouse/SpaceEngineers/blob/master/Sources/Sandbox.Game/Game/World/Generator/MyCompositeShapeProvider.cs#L98

Sandbox.Game.World.Generator::MyCompositeShapeProvider
  public static MyCompositeShapeProvider CreateAsteroidShape(int seed, float size, int generatorEntry)
    var gen = MyCompositeShapes.AsteroidGenerators[result.m_state.Generator];
    gen(seed, size, out result.m_data);

https://github.com/KeenSoftwareHouse/SpaceEngineers/blob/master/Sources/Sandbox.Game/Game/World/Generator/MyCompositeShapes.cs#L289

Sandbox.Game.World.Generator::MyCompositeShapes
  private static void Generator(int version, int seed, float size, out MyCompositeShapeGeneratedData data)
    { // determine primary shape
      case 0: //ShapeType.Torus
      case 1: //ShapeType.Sphere
      [...]
    { // add some additional shapes
      data.FilledShapes[filledShapeCount++] = primaryShape;
      [...] sphere, torus, capsule
    { // make some holes
      [...] // sphere, torus, capsule
    { // generating materials
      [...]
      data.DefaultMaterial = m_surfaceMaterials[(int)random.Next() % m_surfaceMaterials.Count];
      [...]
      int depositCount = Math.Max((int)Math.Log(size), data.FilledShapes.Length);
      data.Deposits = new MyCompositeShapeOreDeposit[depositCount];
      [...]

https://github.com/KeenSoftwareHouse/SpaceEngineers/blob/master/Sources/Sandbox.Game/Game/World/Generator/MyCompositeShapes.cs#L430

Sandbox.Game.World.Generator::MyCompositeShapes
  private static void FillMaterials(int version)
    if (material.MinedOre == "Stone") // Surface
      m_surfaceMaterials.Add(material);

https://github.com/KeenSoftwareHouse/SpaceEngineers/blob/master/Sources/Sandbox.Game/Engine/Voxels/Storage/IMyStorageDataProvider.cs#L84

Sandbox.Engine.Voxels::IMyStorageDataProvider
  MyVoxelMaterialDefinition GetMaterialAtPosition(ref Vector3D localPosition);
