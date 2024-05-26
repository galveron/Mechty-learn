import * as THREE from 'three'
import { GLTF, GLTFLoader } from 'three/addons/loaders/GLTFLoader.js'
import { useEffect, useRef } from "react"

function Rocket() {
    const refContainer = useRef<HTMLDivElement | null>(null);

    useEffect(() => {
        if (!refContainer.current) return

        var side3d = document.getElementById("side-3d")

        const scene = new THREE.Scene()

        const camera = new THREE.PerspectiveCamera(17, window.innerWidth / window.innerHeight, 0.2, 2000)
        camera.position.z = 5
        camera.aspect = 1
        camera.updateProjectionMatrix()
        const renderer = new THREE.WebGLRenderer()
        renderer.setSize(side3d?.offsetWidth ? side3d?.offsetWidth : 0, side3d?.offsetHeight ? side3d?.offsetHeight : 0)
        renderer.setClearColor(0xff40bd)

        const canvas = renderer.domElement
        refContainer.current.appendChild(canvas)

        const light = new THREE.HemisphereLight(0xffffff, 0x080820, 15)
        scene.add(light)
        scene.rotateZ(-0.4)

        const loader = new GLTFLoader().setPath('3dmodels/rocket/')

        canvas.addEventListener("mousemove", onMouseMove)
        let mesh: THREE.Object3D | undefined

        loader.load(
            'rocket.gltf',
            (gltf: GLTF) => {
                mesh = gltf.scene

                mesh.traverse((child: any) => {
                    if (child.isMesh) {
                        child.castShadow = true
                        child.receiveShadow = true
                    }
                });

                scene.add(mesh)
            },
            undefined,
            (error) => {
                console.error('An error happened during loading GLTF:', error)
            })


        function onMouseMove() {
            if (mesh) {
                mesh.rotation.y += 0.04
            }
        }


        function animate() {
            requestAnimationFrame(animate)
            renderer.render(scene, camera)
            if (mesh) {
                mesh.rotation.y += 0.04
            }
        }

        animate()

        function onWindowResize() {
            if (!camera || !renderer) return

            camera.aspect = 1
            camera.updateProjectionMatrix()

            renderer.setSize(side3d?.offsetWidth ? side3d?.offsetWidth : 0, side3d?.offsetHeight ? side3d?.offsetHeight : 0)
        }
        window.addEventListener('resize', onWindowResize)

        return () => {
            window.removeEventListener('resize', onWindowResize)
            if (refContainer.current) {
                refContainer.current.removeChild(renderer.domElement)
            }
            renderer.dispose()
        }
    }, [])

    return (
        <div id="ref-container" ref={refContainer} style={{ width: '100%', height: '100%' }} />

    );
}

export default Rocket