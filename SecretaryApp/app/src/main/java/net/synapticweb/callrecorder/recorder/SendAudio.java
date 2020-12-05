package net.synapticweb.callrecorder.recorder;

import android.util.Log;
import android.webkit.MimeTypeMap;

import java.io.File;

import okhttp3.MediaType;
import okhttp3.MultipartBody;
import okhttp3.OkHttpClient;
import okhttp3.RequestBody;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class SendAudio {
    public void SendAudioFile(File audioFile) {
        SendAudioService service =
                ServiceGenerator.createService(SendAudioService.class);

        Call<ResponseBody> call = service.sendAudioFile(createMultipartBody(audioFile));
        call.enqueue(new Callback<ResponseBody>() {
            @Override
            public void onResponse(Call<ResponseBody> call,
                                   Response<ResponseBody> response) {
                Log.v("Upload", "success");
            }

            @Override
            public void onFailure(Call<ResponseBody> call, Throwable t) {
                Log.e("Upload error:", t.getMessage());
            }
        });
    }

    private MultipartBody.Part createMultipartBody(File file)  {
        return MultipartBody.Part.createFormData("myAudioFile", file.getName(), createRequestBody(file));
    }

    private RequestBody createRequestBody(File file) {
        return RequestBody.create(getMediaType(file.getAbsolutePath()), file);
    }

    private MediaType getMediaType(String url) {
        String extension = MimeTypeMap.getFileExtensionFromUrl(url);
        return MediaType.parse(
                MimeTypeMap.getSingleton().getMimeTypeFromExtension(extension));
    }
}

