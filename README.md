# Fibonacci Sphere visualisation

A Unity visualisation project that demonstrates the natural mathematical beauty of Fibonacci spirals in three dimensional space. This project generates evenly distributed points on a sphere using the golden ratio, revealing the spiral patterns found throughout nature. I originally started this to create a base for creating a mesh for a planet project in unity, but realised there are way easier ways of doing that. 

## Mathematical Foundation

The project implements a point distribution algorithm based on the golden ratio (φ = (1 + √5) / 2), which creates the most uniform possible arrangement of points on a spherical surface. Each point position is calculated using spherical coordinates with Fibonacci angle increments, resulting in the spiral patterns observed in sunflowers, pinecones, nautilus shells, and galaxy formations.

## Visual Features

**Point Distribution**: Generate between 1 and 1000 points uniformly distributed across the sphere surface using mathematically optimal spacing.

**Colour Coding**: White points mark the positions corresponding to Fibonacci sequence numbers, while red points fill the remaining positions, creating clear visual distinction of the mathematical relationships.

**Spiral Connections**: Blue connecting lines between consecutive points reveal the underlying spiral structure and demonstrate how the golden angle creates multiple  spiral arms.

**Interactive Controls**: Real time adjustment of point count, Fibonacci highlighting, spiral offset parameters, and point sizing for detailed exploration of different mathematical relationships.

## Technical Implementation

The core algorithm leverages Unity's mathematics library to compute spherical coordinates using the golden angle method. The `GenerateVertices()` function calculates each point position through:

1. Uniform distribution parameter t based on point index
2. Polar angle phi using arccosine transformation
3. Azimuthal angle theta incremented by the golden angle
4. Conversion to Cartesian coordinates for 3D positioning

The visualization system uses Unity's Gizmo rendering for real time display.

Overall a very fun experiment which arose from the spin off of another project which was inspired by a natual mathematical occurence.



