🟢 Part 1 – Rigid Debris (hard, no deformation)
Manual Steps

New Scene
File → New → General → Delete default objects (X).

Add Ground
Shift + A → Mesh → Plane → S → 40 to scale up.

Add Debris
Shift + A → Mesh → Cube (or Sphere).
Make several cubes, place them high above the plane.

Rigid Body Physics

Select the plane → Physics Properties → Rigid Body → set Type = Passive.

Select all debris → Rigid Body → Type = Active.

Timeline
Set End Frame = 200 → Press Space/Play → debris falls and collides.

Python Code (Rigid)
import bpy, random

# Clean scene
bpy.ops.object.select_all(action='SELECT')
bpy.ops.object.delete(use_global=False)

# Ground plane
bpy.ops.mesh.primitive_plane_add(size=40, location=(0,0,0))
ground = bpy.context.active_object
bpy.ops.rigidbody.object_add()
ground.rigid_body.type = 'PASSIVE'

# Rigid debris
for i in range(25):
    x = random.uniform(-4, 4)
    y = random.uniform(-4, 4)
    z = random.uniform(10, 15)
    bpy.ops.mesh.primitive_cube_add(size=random.uniform(0.4,0.7), location=(x,y,z))
    obj = bpy.context.active_object
    bpy.ops.rigidbody.object_add()
    obj.rigid_body.type = 'ACTIVE'

# Set timeline
bpy.context.scene.frame_end = 200


Run → debris falls and bounces like solid rocks.

🟠 Part 2 – Semi-Rigid Debris (hard fall + slight wobble)

Blender does not have a single “semi-rigid” solver.
The easiest hybrid is Rigid Body for falling + a Soft Body modifier for mild flexing.

Manual Steps

Follow the Rigid Debris steps to create the plane and cubes and add Rigid Body physics.

Select each debris piece → Modifier Properties → Add Modifier → Soft Body.

In the Soft Body panel:

Goal → Uncheck Use Goal (so it moves freely).

Edges → Check Use Edges (allows shape bending).

Settings (start values):

Pull: 0.2

Push: 0.2

Damping: 5.0

Scene → Scene Properties → Rigid Body World:

Substeps Per Frame: 10

Solver Iterations: 20

Timeline End: 200 → Play → debris falls like rigid pieces but wobbles slightly on impact.

Python Code (Semi-Rigid)
import bpy, random

# Clean scene
bpy.ops.object.select_all(action='SELECT')
bpy.ops.object.delete(use_global=False)

# Ground plane (passive rigid body)
bpy.ops.mesh.primitive_plane_add(size=40, location=(0,0,0))
ground = bpy.context.active_object
bpy.ops.rigidbody.object_add()
ground.rigid_body.type = 'PASSIVE'

# Semi-rigid debris
for i in range(20):
    x = random.uniform(-4, 4)
    y = random.uniform(-4, 4)
    z = random.uniform(12, 18)
    bpy.ops.mesh.primitive_cube_add(size=random.uniform(0.3,0.7), location=(x,y,z))
    obj = bpy.context.active_object
    bpy.ops.rigidbody.object_add()
    obj.rigid_body.type = 'ACTIVE'
    # Soft Body for slight deformation
    bpy.ops.object.modifier_add(type='SOFT_BODY')
    sb = obj.soft_body
    sb.use_goal = False      # free motion
    sb.use_edges = True      # allow bending
    sb.pull = 0.2
    sb.push = 0.2
    sb.damping = 5.0

# Improve collision accuracy
scene = bpy.context.scene
scene.frame_end = 200
scene.rigidbody_world.steps_per_second = 240
scene.rigidbody_world.solver_iterations = 20
