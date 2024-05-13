// Techniques for counting blocks on a grid.
// This is unfortunately needed because the ingame API does not expose the grid block count.
// Feature request: https://support.keenswh.com/spaceengineers/pc/topic/feature-request-ingame-script-api-expose-grid-block-count

// countBlocksWalkGrid counts all blocks by walking the reachable grid positions.
// It walks all reachable blocks by position starting from the programmable block.
private int countBlocksWalkGrid() {
    var grid = Me.CubeGrid;
    var visit = new Stack<Vector3I>();
    visit.Push(Me.Position); // start from the programmable block
    var visited = new HashSet<string>();
    var entities = new HashSet<long>();
    int other = 0;
    while (visit.Count() > 0) {
        Vector3I p = visit.Pop();
        if (!grid.CubeExists(p)) continue;
        var k = p.X + "/" + p.Y + "/" + p.Z;
        if (visited.Contains(k)) continue;
        visited.Add(k);
        visit.Push(new Vector3I(p.X+1, p.Y, p.Z));
        visit.Push(new Vector3I(p.X, p.Y+1, p.Z));
        visit.Push(new Vector3I(p.X, p.Y, p.Z+1));
        visit.Push(new Vector3I(p.X-1, p.Y, p.Z));
        visit.Push(new Vector3I(p.X, p.Y-1, p.Z));
        visit.Push(new Vector3I(p.X, p.Y, p.Z-1));
        IMySlimBlock block = grid.GetCubeBlock(p);
        if (block == null) {
            other++; // non-terminal blocks like armor, rotor, etc
        } else {
            entities.Add(block.FatBlock.EntityId);
        }
    }
    return entities.Count() + other;
}

// countBlocksAllPositions counts all blocks by searching the entire x/y/z min/max grid.
// It is pretty slow as most likely the grid isn't a cube but a small part of it.
private int countBlocksAllPositions() {
    var grid = Me.CubeGrid;
    var entities = new HashSet<long>();
    int other = 0;
    for (int x = grid.Min.X; x <= grid.Max.X; x++) {
        for (int y = grid.Min.Y; y <= grid.Max.Y; y++) {
            for(int z = grid.Min.Z; z <= grid.Max.Z; z++) {
                Vector3I pos = new Vector3I(x, y, z);
                if (!grid.CubeExists(pos)) continue;
                IMySlimBlock block = grid.GetCubeBlock(pos);
                if (block == null) {
                    other++; // non-terminal blocks like armor, rotor, etc
                } else {
                    // the loop will iterate all positions, so multiple times on blocks larger than 1x1x1
                    // use the entity id to disambiguate
                    entities.Add(block.FatBlock.EntityId);
                }
            }
        }
    }
    return entities.Count() + other;
}
