using UnityEngine;

using UnityEngine.Networking;
using Debug = AndromedaEngine.Debug;

namespace Silly18.RUltimateSDK.Templates.Utils;

/// <summary>
/// The Game Engine Wrapper (UnityEngine)
/// </summary>
internal static class EngineUtils
{
    public static class iL2CPPWrapper
{
    /// <summary>
    /// [pasted utils]
    /// </summary>
    public static class Serialization
    {

        public static byte[]? ToByteArray(Il2CppSystem.Object? obj)
        {
            if (obj == null) return null;
            try
            {
                var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var ms = new Il2CppSystem.IO.MemoryStream();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [Obsolete("Obsolete")]
        public static byte[]? ToByteArray(object obj)
        {
            if (obj == null) return null;
            try
            {
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var ms = new MemoryStream();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [Obsolete("Obsolete")]
        public static T? FromByteArray<T>(byte[]? data)
        {
            if (data == null) return default;
            try
            {
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                using var ms = new System.IO.MemoryStream(data);
                var obj = bf.Deserialize(ms);
                return (T)obj;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }

        public static T? IL2CPPFromByteArray<T>(byte[] data)
        {
            if (data == null) return default;
            try
            {
                var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var ms = new Il2CppSystem.IO.MemoryStream(data);
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }

            [Obsolete]
            public static T? FromIL2CPPToManaged<T>(Il2CppSystem.Object? obj)
        {
            return FromByteArray<T>(ToByteArray(obj));
        }

            [Obsolete]
            public static T? FromManagedToIL2CPP<T>(object obj)
        {
            return IL2CPPFromByteArray<T>(ToByteArray(obj));
        }

        public static object[] FromIL2CPPArrayToManagedArray(Il2CppSystem.Object[] obj)
        {
            var Parameters = new object[obj.Length];
            for (var i = 0; i < obj.Length; i++)
                if (obj[i].GetIl2CppType().Attributes == Il2CppSystem.Reflection.TypeAttributes.Serializable)
                    Parameters[i] = FromIL2CPPToManaged<object>(obj[i]);
                else
                    Parameters[i] = obj[i];
            return Parameters;
        }

        public static Il2CppSystem.Object[] FromManagedArrayToIL2CPPArray(object[] obj)
        {
            Il2CppSystem.Object[] Parameters = new Il2CppSystem.Object[obj.Length];
            for (var i = 0; i < obj.Length; i++)
            {
                if (obj[i].GetType().Attributes == System.Reflection.TypeAttributes.Serializable)
                    Parameters[i] = FromManagedToIL2CPP<Il2CppSystem.Object>(obj[i]);
                else
                    Parameters[i] = (Il2CppSystem.Object)obj[i];
            }
            return Parameters;
        }
    }
}
    public struct Conversion
    {
        public static Texture2D MakeTextureGrayscale(Texture2D originalTexture)
        {
            // Create a new texture with the same dimensions
            Texture2D grayscaleTexture = new Texture2D(originalTexture.width, originalTexture.height);
            
            // Get all the pixels
            Color[] pixels = originalTexture.GetPixels();
            
            // Convert each pixel to grayscale
            for (int i = 0; i < pixels.Length; i++)
            {
                float gray = pixels[i].r * 0.299f + pixels[i].g * 0.587f + pixels[i].b * 0.114f;
                pixels[i] = new Color(gray, gray, gray, pixels[i].a); // Keep original alpha
            }
            
            // Apply the grayscale pixels to the new texture
            grayscaleTexture.SetPixels(pixels);
            grayscaleTexture.Apply();
            
            return grayscaleTexture;
        }
        public static Sprite MakeSpriteGrayscale(Sprite originalSprite)
        {
            Texture2D originalTexture = originalSprite.texture;
            // Make the texture readable if it isn't already
            if (!originalTexture.isReadable)
            {
                AndromedaEngine.Debug.Console.Log("Texture not readable, creating readable copy...", Debug.Console.LogLevel.Error);
                
                // Create a readable copy using RenderTexture
                RenderTexture renderTex = RenderTexture.GetTemporary(originalTexture.width, originalTexture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
                Graphics.Blit(originalTexture, renderTex);
                
                RenderTexture previous = RenderTexture.active;
                RenderTexture.active = renderTex;
                
                Texture2D readableTexture = new Texture2D(originalTexture.width, originalTexture.height);
                readableTexture.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
                readableTexture.Apply();
                
                RenderTexture.active = previous;
                RenderTexture.ReleaseTemporary(renderTex);
                
                originalTexture = readableTexture;
            }
            
            // Now get pixels and convert to grayscale
            Color[] pixels = originalTexture.GetPixels();
            
            for (int i = 0; i < pixels.Length; i++)
            {
                float gray = pixels[i].r * 0.299f + pixels[i].g * 0.587f + pixels[i].b * 0.114f;
                pixels[i] = new Color(gray, gray, gray, pixels[i].a);
            }
            
            Texture2D grayscaleTexture = new Texture2D(originalTexture.width, originalTexture.height);
            grayscaleTexture.SetPixels(pixels);
            grayscaleTexture.Apply();
            
            Sprite grayscaleSprite = Sprite.Create(
                grayscaleTexture,
                originalSprite.rect,
                originalSprite.pivot,
                originalSprite.pixelsPerUnit
            );
            
            grayscaleSprite.name = originalSprite.name;
            return grayscaleSprite;
        }
        [System.Serializable]
        public struct HSBColor
        {
            public float h;
            public float s;
            public float b;
            public float a;
        
            public HSBColor(float h, float s, float b, float a)
            {
                this.h = h;
                this.s = s;
                this.b = b;
                this.a = a;
            }
        
            public HSBColor(float h, float s, float b)
            {
                this.h = h;
                this.s = s;
                this.b = b;
                this.a = 1f;
            }
        
            public HSBColor(Color col)
            {
                HSBColor temp = FromColor(col);
                h = temp.h;
                s = temp.s;
                b = temp.b;
                a = temp.a;
            }
        
            public static HSBColor FromColor(Color color)
            {
                HSBColor ret = new HSBColor(0f, 0f, 0f, color.a);
        
                float r = color.r;
                float g = color.g;
                float b = color.b;
        
                float max = Mathf.Max(r, Mathf.Max(g, b));
        
                if (max <= 0)
                {
                    return ret;
                }
        
                float min = Mathf.Min(r, Mathf.Min(g, b));
                float dif = max - min;
        
                if (max > min)
                {
                    if (g == max)
                    {
                        ret.h = (b - r) / dif * 60f + 120f;
                    }
                    else if (b == max)
                    {
                        ret.h = (r - g) / dif * 60f + 240f;
                    }
                    else if (b > g)
                    {
                        ret.h = (g - b) / dif * 60f + 360f;
                    }
                    else
                    {
                        ret.h = (g - b) / dif * 60f;
                    }
                    if (ret.h < 0)
                    {
                        ret.h = ret.h + 360f;
                    }
                }
                else
                {
                    ret.h = 0;
                }
        
                ret.h *= 1f / 360f;
                ret.s = (dif / max) * 1f;
                ret.b = max;
        
                return ret;
            }
        
            public static Color ToColor(HSBColor hsbColor)
            {
                float r = hsbColor.b;
                float g = hsbColor.b;
                float b = hsbColor.b;
                if (hsbColor.s != 0)
                {
                    float max = hsbColor.b;
                    float dif = hsbColor.b * hsbColor.s;
                    float min = hsbColor.b - dif;
        
                    float h = hsbColor.h * 360f;
        
                    if (h < 60f)
                    {
                        r = max;
                        g = h * dif / 60f + min;
                        b = min;
                    }
                    else if (h < 120f)
                    {
                        r = -(h - 120f) * dif / 60f + min;
                        g = max;
                        b = min;
                    }
                    else if (h < 180f)
                    {
                        r = min;
                        g = max;
                        b = (h - 120f) * dif / 60f + min;
                    }
                    else if (h < 240f)
                    {
                        r = min;
                        g = -(h - 240f) * dif / 60f + min;
                        b = max;
                    }
                    else if (h < 300f)
                    {
                        r = (h - 240f) * dif / 60f + min;
                        g = min;
                        b = max;
                    }
                    else if (h <= 360f)
                    {
                        r = max;
                        g = min;
                        b = -(h - 360f) * dif / 60 + min;
                    }
                    else
                    {
                        r = 0;
                        g = 0;
                        b = 0;
                    }
                }
        
                return new Color(Mathf.Clamp01(r),Mathf.Clamp01(g),Mathf.Clamp01(b),hsbColor.a);
            }
        
            public Color ToColor()
            {
                return ToColor(this);
            }
        
            public override string ToString()
            {
                return "H:" + h + " S:" + s + " B:" + b;
            }
        
            public static HSBColor Lerp(HSBColor a, HSBColor b, float t)
            {
                float h,s;
        
                //check special case black (color.b==0): interpolate neither hue nor saturation!
                //check special case grey (color.s==0): don't interpolate hue!
                if(a.b==0){
                    h=b.h;
                    s=b.s;
                }else if(b.b==0){
                    h=a.h;
                    s=a.s;
                }else{
                    if(a.s==0){
                        h=b.h;
                    }else if(b.s==0){
                        h=a.h;
                    }else{
                        // works around bug with LerpAngle
                        float angle = Mathf.LerpAngle(a.h * 360f, b.h * 360f, t);
                        while (angle < 0f)
                            angle += 360f;
                        while (angle > 360f)
                            angle -= 360f;
                        h=angle/360f;
                    }
                    s=Mathf.Lerp(a.s,b.s,t);
                }
                return new HSBColor(h, s, Mathf.Lerp(a.b, b.b, t), Mathf.Lerp(a.a, b.a, t));
            }
        }
        public static Color HexToColor(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out Color color);
            return color;
        }

        public static string ColorToHex(Color color)
        {
            return $"#{ColorUtility.ToHtmlStringRGB(color)}";
        }
    }

    public struct Assets
    {

        #region Media
        public static T LoadAsset<T>(Uri path)
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(AudioClip):
                    return (T)(object)AudioClip(path);

                case Type t when t == typeof(Texture2D):
                    return (T)(object)Texture(path);

                case Type t when t == typeof(GameObject):
                    return (T)(object)AssetBundle(path);

                default:
                    throw new ArgumentException($"Unsupported asset type: {typeof(T)}");
            }
        }
        // }
        public static AudioClip? AudioClip(Uri url)
        {
            UnityWebRequest www = UnityWebRequest.Get(url.ToString());
            var operation = www.SendWebRequest();
            while (!operation.isDone) System.Threading.Thread.Sleep(1);
            if (www.isNetworkError || www.isHttpError) return null;
            AudioClip clip = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false, 0);

            if (clip == null) return null;
            clip.name = Uri.UnescapeDataString(Path.GetFileNameWithoutExtension(url.AbsolutePath));
            return clip;
        }

        public static GameObject? CreateAudio(Uri url, float volume = 1f, bool loop = true, bool bypassAllEffects = true)
        {
            UnityWebRequest www = UnityWebRequest.Get(url.ToString());
            var operation = www.SendWebRequest();
            while (!operation.isDone) System.Threading.Thread.Sleep(1);
            if (www.isNetworkError || www.isHttpError) return null;
            AudioClip clip = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false, 0);

            if (clip == null) return null;

            var src = new GameObject($"Audio: [{url.AbsolutePath}]").AddComponent<AudioSource>();
            if (url.IsFile)
            {
                src.name = Path.GetFileNameWithoutExtension(url.AbsolutePath);
                clip.name = src.name;
            }

            src.clip = clip;
            src.hideFlags += 32;
            src.loop = loop;
            src.volume = volume;
            src.bypassListenerEffects = bypassAllEffects;
            src.bypassReverbZones = bypassAllEffects;
            src.Play();
            UnityEngine.Object.DontDestroyOnLoad(src);
            return src.gameObject;
        }

        public static AudioSource? AudioOverride(Uri url)
        {
            UnityWebRequest www = UnityWebRequest.Get(url.ToString());
            var operation = www.SendWebRequest();
            while (!operation.isDone) System.Threading.Thread.Sleep(1);
            if (www.isNetworkError || www.isHttpError) return null;
            AudioClip clip = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false, 0);
            AudioSource? audiosrc = null;

            if (audiosrc == null || clip == null) return null;
            if (url.IsFile) clip.name = Path.GetFileNameWithoutExtension(url.LocalPath);
            audiosrc.clip = clip;
            audiosrc.hideFlags += 32;
            audiosrc.Play();
            return audiosrc;
        }

        #endregion

        #region Imagebased

        public static Texture2D? INTERNAL_Texture(byte[] data)
        {
            Texture2D texture = new(0, 0);
            ImageConversion.LoadImage(texture, data);
            if (texture != null) texture.name += ".dotNET.EmbeddedResource";
            return texture;
        }

        public static Texture2D? Texture(Uri? url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            byte[] data;
            if (url.IsFile) data = File.ReadAllBytes(url.LocalPath); // Works with file:// or plain path
            else if (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps)
            {
                using HttpClient http = new();
                data = http.GetByteArrayAsync(url.ToString()).GetAwaiter().GetResult();
            }
            else throw new NotSupportedException($"Unsupported URI scheme: {url.Scheme}");

            Texture2D texture2D = new(2048, 2048); // Always give a dummy size
            ImageConversion.LoadImage(texture2D, data);
            texture2D.name = Path.GetFileNameWithoutExtension(url.LocalPath);
            return texture2D;
        }
        public static RenderTexture? TextureR(Uri? url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            byte[] data;

            if (url.IsFile)
                data = File.ReadAllBytes(url.LocalPath);
            else if (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps)
            {
                using HttpClient http = new();
                data = http.GetByteArrayAsync(url.ToString()).GetAwaiter().GetResult();
            }
            else
                throw new NotSupportedException($"Unsupported URI scheme: {url.Scheme}");

            // 🔧 FIX: Use Texture2D for loading
            Texture2D tempTex = new Texture2D(2, 2);
            if (!tempTex.LoadImage(data))
                throw new Exception("Failed to load image");

            // 🔧 Then convert to RenderTexture
            RenderTexture texture2D = new RenderTexture(tempTex.width, tempTex.height, 0);
            Graphics.Blit(tempTex, texture2D);

            texture2D.name = Path.GetFileNameWithoutExtension(
                url.IsFile ? url.LocalPath : url.AbsolutePath
            );

            return texture2D;
        }
        public static Sprite Sprite(Uri dir)
            => Texture(dir).ToSprite();

        public static Sprite Data_LoadSprite(Uri? dir)
            => Texture(dir).ToSprite();

        #endregion

        #region Source

        public static UnityEngine.GameObject? INTERNAL_AssetBundle(byte[]? data, bool keep = false)
        {
            if(data?.Length == 0) return null;
            AssetBundle? bundle = UnityEngine.AssetBundle.LoadFromMemory(data);

            GameObject? obj = bundle.LoadAsset<GameObject>(bundle.GetAllAssetNames()[0]);
            GameObject? instance = UnityEngine.Object.Instantiate(obj);
            if (keep is true)  UnityEngine.Object.DontDestroyOnLoad(instance);
            bundle.Unload(false);
            return instance;
        }


        public static UnityEngine.GameObject AssetBundle(Uri? url, bool keep = false)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            byte[]? data = null;
            if (url.IsFile) data = File.ReadAllBytes(url.LocalPath); // Works with file:// or plain path
            else if (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps)
            {
                HttpClient http = new();
                data = http.GetByteArrayAsync(url.ToString()).GetAwaiter().GetResult();

            }
          
            AssetBundle? bundle = UnityEngine.AssetBundle.LoadFromMemory(data);
            GameObject? obj = bundle.LoadAsset<GameObject>(bundle.GetAllAssetNames()[0]);
            GameObject? instance = UnityEngine.Object.Instantiate(obj);
            if (keep) UnityEngine.Object.DontDestroyOnLoad(instance);
            bundle.Unload(false);
            return instance;
        }

        #endregion
    }
}



#region Classes

public static class UnityFileExplorer
{
    /// <summary>
    /// Find GameObject by path, including hidden ones with HideAndDontSave
    /// Works like GameObject.Find() but finds hidden objects too
    /// </summary>
    /*public static GameObject? FindObject(string path)
    {
        if (string.IsNullOrEmpty(path))
            return null;
        
        // Get all GameObjects including hidden ones
        GameObject[] allObjects = UnityEngine.Resources.FindObjectsOfTypeAll<GameObject>();
        
        // Split the path into parts
        string[] pathParts = path.Split('/');
        
        // Find objects that match the path
        return allObjects.FirstOrDefault(obj =>
            obj != null &&
            obj.scene.isLoaded &&
            DoesPathMatch(obj, pathParts)
        );
    }*/
    
    /// <summary>
    /// Find all GameObjects by path, including hidden ones
    /// </summary>
   /* public static GameObject[] FindObjects(string path)
    {
        if (string.IsNullOrEmpty(path))
            return new GameObject[0];
        
        GameObject[] allObjects = UnityEngine.Resources.FindObjectsOfTypeAll<GameObject>();
        string[] pathParts = path.Split('/');
        
        return allObjects.Where(obj =>
            obj != null &&
            obj.scene.isLoaded &&
            DoesPathMatch(obj, pathParts)
        ).ToArray();
    }*/
    
    /// <summary>
    /// Find GameObject by partial path match
    /// </summary>
  /*  public static GameObject? FindObjectContaining(string partialPath)
    {
        if (string.IsNullOrEmpty(partialPath))
            return null;
        
        GameObject[] allObjects = UnityEngine.Resources.FindObjectsOfTypeAll<GameObject>();
        
        return allObjects.FirstOrDefault(obj =>
            obj != null &&
            obj.scene.isLoaded &&
            GetFullPath(obj).Contains(partialPath)
        );
    }*/
    
    /// <summary>
    /// Check if GameObject matches the given path parts
    /// </summary>
    private static bool DoesPathMatch(GameObject obj, string[] pathParts)
    {
        if (pathParts.Length == 0)
            return false;
        
        // Start from the target object and work backwards through parents
        Transform current = obj.transform;
        
        // Check if the last part matches the object name
        if (current.name != pathParts[pathParts.Length - 1])
            return false;
        
        // Work backwards through the path
        for (int i = pathParts.Length - 2; i >= 0; i--)
        {
            current = current.parent;
            if (current == null || current.name != pathParts[i])
                return false;
        }
        
        return true;
    }
    
    /// <summary>
    /// Get the full hierarchy path of a GameObject
    /// </summary>
    private static string GetFullPath(GameObject obj)
    {
        string path = obj.name;
        Transform parent = obj.transform.parent;
        
        while (parent != null)
        {
            path = parent.name + "/" + path;
            parent = parent.parent;
        }
        
        return path;
    }
}

// Extension methods for even cleaner usage
public static class GameObjectExtensions
{
    /// <summary>
    /// Find hidden GameObject and get or add component safely
    /// </summary>
   /* public static T? FindAndGetComponent<T>(string path) where T : Component
    {
        GameObject? obj = UnityFileExplorer.FindObject(path);
        return obj?.GetComponent<T>();
    }

    /// <summary>
    /// Find hidden GameObject and get or add component safely
    /// </summary>
    public static T? FindAndGetOrAddComponent<T>(string path) where T : Component
    {
        GameObject? obj = UnityFileExplorer.FindObject(path);
        if (obj == null) return null;

        T component = obj.GetComponent<T>();
        if (component == null)
        {
            component = obj.AddComponent<T>();
        }

        component.hideFlags = HideFlags.HideAndDontSave;
        return component;
    }*/
   public static T? Instantiate<T>(this T x, Transform? parent = null) where T : UnityEngine.Object
    {
        return UnityEngine.Object.Instantiate<T>(x, parent);
    }
}

#endregion

#region  ClassExt 
public static class TextureExtensions
{
    public static Sprite ToSprite(this Texture2D texture)
    {
      
        return Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            Vector2.zero 
        );
    }

    public static Texture2D? Change(this Texture2D texture, Uri dir) => EngineUtils.Assets.Texture(dir);
}


public static class ImageExtenisions
{
    public static Sprite? Replace(this Sprite? image, Texture2D? texture)
    {
        return Sprite.Create(texture, 
            image.rect, 
            image.pivot, 
            image.pixelsPerUnit, 
            0, 
            SpriteMeshType.FullRect, 
            image.border);
    }
}
public static class ObjectExtension
{
    /// <summary>
    /// Gets an existing component of type T from the GameObject, or adds one if it doesn't exist.
    /// </summary>
    /// <typeparam name="T">The component type to get or add</typeparam>
    /// <param name="go">The GameObject to operate on</param>
    /// <returns>The existing or newly added component of type T</returns>

    public static UnityEngine.GameObject CreateIsolatedObject(this GameObject x, bool IsOnTop = false)
    {
        GameObject clone = UnityEngine.Object.Instantiate(x.gameObject, x.transform.parent);
        clone.name = x.gameObject.name + "_Isolated";

         if(IsOnTop)
         {
            clone.transform.SetSiblingIndex(0);
         }      
        return clone;
    }
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        // Try to get the existing component
        T component = go.GetComponent<T>();

        // If it doesn't exist, add it
        if (component == null)
        {
            component = go.AddComponent<T>();
        }

        return component;
    }

    // Alternative implementation with null checking
    public static T GetOrAddComponentSafe<T>(this GameObject go) where T : Component
    {
        if (go == null)
        {
            throw new System.ArgumentNullException(nameof(go), "GameObject cannot be null");
        }

        T component = go.GetComponent<T>();
        return component != null ? component : go.AddComponent<T>();
    }

    // Version that works with interface types (if needed)
    //public static T? GetOrAddComponent<T>(this GameObject go, Il2CppSystem.Type componentType) where T : Component
    //{
    //    if (go == null || componentType == null)
    //        return null;

    //    Component component = go.GetComponent(componentType);
    //    if (component == null)
    //    {
    //        component = go.AddComponent(componentType);
    //    }

    //    return component as T;
    //}
    public static void Destroy(this UnityEngine.Object x) => UnityEngine.Object.Destroy(x);
    public static void DestroyImmediate(this UnityEngine.Object x, bool allowDestroyingAssets) => 
        UnityEngine.Object.DestroyImmediate(x, allowDestroyingAssets);

    public static void DestoryObject(this UnityEngine.Object x) => UnityEngine.Object.DestroyObject(x);
    public static void DontDestoryOnLoad(this UnityEngine.Object x) => UnityEngine.Object.DontDestroyOnLoad(x);
    public static void DestroyAllChildren(this Transform t)
    {
        if (t.childCount == 0) return;

        for (int i = t.childCount - 1; i >= 0; i--)
        {
            UnityEngine.Object.Destroy(t.GetChild(i).gameObject);
        }
    }
}

public static class ComponentExtensions
{
    public static Color ChangeColor(this Color x, Color color)
    {
        return x = color;
    }
}
#endregion