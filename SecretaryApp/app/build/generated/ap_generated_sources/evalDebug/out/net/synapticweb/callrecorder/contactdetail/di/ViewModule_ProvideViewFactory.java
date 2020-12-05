// Generated by Dagger (https://dagger.dev).
package net.synapticweb.callrecorder.contactdetail.di;

import dagger.internal.Factory;
import dagger.internal.Preconditions;
import net.synapticweb.callrecorder.contactdetail.ContactDetailContract;

@SuppressWarnings({
    "unchecked",
    "rawtypes"
})
public final class ViewModule_ProvideViewFactory implements Factory<ContactDetailContract.View> {
  private final ViewModule module;

  public ViewModule_ProvideViewFactory(ViewModule module) {
    this.module = module;
  }

  @Override
  public ContactDetailContract.View get() {
    return provideView(module);
  }

  public static ViewModule_ProvideViewFactory create(ViewModule module) {
    return new ViewModule_ProvideViewFactory(module);
  }

  public static ContactDetailContract.View provideView(ViewModule instance) {
    return Preconditions.checkNotNull(instance.provideView(), "Cannot return null from a non-@Nullable @Provides method");
  }
}