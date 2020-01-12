using UnityEngine;
using UnityEditor;

class ImportTexture : AssetPostprocessor {
    void OnPreprocessTexture () {
        if (assetPath.Contains("Textures")) {
            Debug.Log ("Importing & configuring new Texture!");
            TextureImporter mti  = (TextureImporter)assetImporter;
            mti.textureType = TextureImporterType.Sprite;
            mti.textureShape = TextureImporterShape.Texture2D;
            mti.convertToNormalmap = false;
            mti.maxTextureSize = 2048;
        }
    }
}