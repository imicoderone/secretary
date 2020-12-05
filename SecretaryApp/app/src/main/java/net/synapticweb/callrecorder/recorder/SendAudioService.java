package net.synapticweb.callrecorder.recorder;

import okhttp3.MultipartBody;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Multipart;
import retrofit2.http.POST;
import retrofit2.http.Part;

public interface SendAudioService {
    @Multipart
    @POST("/api/Recognition/Recognize")
    Call<ResponseBody> sendAudioFile(@Part MultipartBody.Part file);
}
