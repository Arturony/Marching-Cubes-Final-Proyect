# Proyecto Final Computación Visual

Basado en el video https://www.youtube.com/watch?v=M3iI2l0ltbE <br>
Repositorio original: https://github.com/SebLague/Marching-Cubes

# Marching Cubes

Para este proyecto se usó el generador de terreno creado por Sebastian Lague para crear un entorno interactivo. El terreno se crea por medio de un compute shader que calcula la geometría basado en un generador de ruido que actúa como volumen a renderizar. A esta geometría luego se le implementa una textura basada en un gradiante, para dar la impresión de profundidad y altura. 

<img width="293" alt="image" src="https://user-images.githubusercontent.com/32319160/205808618-d1f5485b-8caa-4aec-8f0c-8dc5eb03ea0d.png">

<img width="291" alt="image" src="https://user-images.githubusercontent.com/32319160/205808669-3dfa8eeb-137b-4d07-bef9-a513787a2dd9.png">

Este código permite la generación estática o dinámica por chunks para ahorrar memoria. Para poder implementar colliders en la forma dinámica se tuvo que modificar el creador de chunks para que este actualizara los "Mesh Colliders" cada que un nuevo chunk se hacía visible. De esta manera el terreno se comporta como un objeto sólido. 4

<img width="283" alt="image" src="https://user-images.githubusercontent.com/32319160/205808997-2d41aa49-4002-4781-9561-275931e8edde.png">

<img width="254" alt="image" src="https://user-images.githubusercontent.com/32319160/205809026-69e6440b-d24d-4a01-9909-b960b6927453.png">

# Movimiento del jugador

Se usó un controlador estándar para generar el movimiento del jugador. Este movimiento permite cambiar la aceleración y la fuerza de salto.

<img width="292" alt="image" src="https://user-images.githubusercontent.com/32319160/205809383-a4d50248-207b-44ee-9035-6051cc2f5ce7.png">

# Movimiento de la Cámara

Se usó otro controlador que está agregado a un objeto diferente al jugador. Así se evita que el collider rote de maneras no deseadas al rotar el objeto con el movimiento del mouse.

<img width="293" alt="image" src="https://user-images.githubusercontent.com/32319160/205809647-9dc7b1ed-d89a-4e15-be7a-579d63e4c2e6.png">

<img width="118" alt="image" src="https://user-images.githubusercontent.com/32319160/205809672-f1823197-4060-4f5d-9834-cda7b3ae0fea.png">

# Post Processing

Se usó el package "Post Processing" de Unity Technologies para poder crear efectos globales al renderizar la vista. Efectos como color corerction, bloom, depth of field, entre otros, le dan un aspecto diferente al juego.

<img width="685" alt="image" src="https://user-images.githubusercontent.com/32319160/205809927-db5905f8-45ff-44c9-8849-18363c5e8a69.png">

<img width="680" alt="image" src="https://user-images.githubusercontent.com/32319160/205809967-03f6052b-7cb5-41b3-a155-dafec63b4f12.png">

<img width="278" alt="image" src="https://user-images.githubusercontent.com/32319160/205810121-709976e4-bf83-43be-ba64-4f440d19b8b8.png">


# Fog

La niebla se creó con la utilidad de lighting del editor de unity. Esta se usa para dar la impresión de una distancia de dibujado mayor y ocultar espacios que harían que la skybox fuera visible.

<img width="284" alt="image" src="https://user-images.githubusercontent.com/32319160/205810149-32c27b77-dd4b-4126-8814-09dc3f1f5c97.png">

# Partículas de lluvia

También se agregó un efecto de lluvia por medio del uso de sistema de partículas de Unity. Se tienen dos emisores. Uno que es la lluvia como tal, y otro que se genera cuando estas partículas chocan con un objeto, dando la impresión de salpicaduras de agua.

<img width="477" alt="image" src="https://user-images.githubusercontent.com/32319160/205810439-f7860df9-4cd6-489d-88e9-8fdf5a5e81e3.png">

