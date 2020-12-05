// Generated by Dagger (https://dagger.dev).
package net.synapticweb.callrecorder.di;

import android.content.Context;
import dagger.internal.DoubleCheck;
import dagger.internal.InstanceFactory;
import dagger.internal.Preconditions;
import javax.inject.Provider;
import net.synapticweb.callrecorder.contactdetail.ContactDetailContract;
import net.synapticweb.callrecorder.contactdetail.ContactDetailFragment;
import net.synapticweb.callrecorder.contactdetail.ContactDetailFragment_MembersInjector;
import net.synapticweb.callrecorder.contactdetail.ContactDetailPresenter;
import net.synapticweb.callrecorder.contactdetail.ContactDetailPresenter_Factory;
import net.synapticweb.callrecorder.contactdetail.EditContactActivity;
import net.synapticweb.callrecorder.contactdetail.EditContactActivity_MembersInjector;
import net.synapticweb.callrecorder.contactdetail.di.ContactDetailComponent;
import net.synapticweb.callrecorder.contactslist.ContactsListContract;
import net.synapticweb.callrecorder.contactslist.ContactsListFragment;
import net.synapticweb.callrecorder.contactslist.ContactsListFragment_MembersInjector;
import net.synapticweb.callrecorder.contactslist.ContactsListPresenter;
import net.synapticweb.callrecorder.contactslist.ContactsListPresenter_Factory;
import net.synapticweb.callrecorder.contactslist.di.ContactsListComponent;
import net.synapticweb.callrecorder.contactslist.di.ViewModule;
import net.synapticweb.callrecorder.contactslist.di.ViewModule_ProvideViewFactory;
import net.synapticweb.callrecorder.data.Repository;
import net.synapticweb.callrecorder.recorder.RecorderService;
import net.synapticweb.callrecorder.recorder.RecorderService_MembersInjector;

@SuppressWarnings({
    "unchecked",
    "rawtypes"
})
public final class DaggerAppComponent implements AppComponent {
  private Provider<Context> contextProvider;

  private Provider<Repository> provideRepositoryProvider;

  private DaggerAppComponent(RepositoryModule repositoryModuleParam, Context contextParam) {

    initialize(repositoryModuleParam, contextParam);
  }

  public static AppComponent.Factory factory() {
    return new Factory();
  }

  @SuppressWarnings("unchecked")
  private void initialize(final RepositoryModule repositoryModuleParam,
      final Context contextParam) {
    this.contextProvider = InstanceFactory.create(contextParam);
    this.provideRepositoryProvider = DoubleCheck.provider(RepositoryModule_ProvideRepositoryFactory.create(repositoryModuleParam, contextProvider));
  }

  @Override
  public void inject(EditContactActivity activity) {
    injectEditContactActivity(activity);}

  @Override
  public void inject(RecorderService service) {
    injectRecorderService(service);}

  @Override
  public ContactsListComponent.Factory contactsListComponent() {
    return new ContactsListComponentFactory();}

  @Override
  public ContactDetailComponent.Factory contactDetailComponent() {
    return new ContactDetailComponentFactory();}

  private EditContactActivity injectEditContactActivity(EditContactActivity instance) {
    EditContactActivity_MembersInjector.injectRepository(instance, provideRepositoryProvider.get());
    return instance;
  }

  private RecorderService injectRecorderService(RecorderService instance) {
    RecorderService_MembersInjector.injectRepository(instance, provideRepositoryProvider.get());
    return instance;
  }

  private static final class Factory implements AppComponent.Factory {
    @Override
    public AppComponent create(Context context) {
      Preconditions.checkNotNull(context);
      return new DaggerAppComponent(new RepositoryModule(), context);
    }
  }

  private final class ContactsListComponentFactory implements ContactsListComponent.Factory {
    @Override
    public ContactsListComponent create(ViewModule module) {
      Preconditions.checkNotNull(module);
      return new ContactsListComponentImpl(module);
    }
  }

  private final class ContactsListComponentImpl implements ContactsListComponent {
    private Provider<ContactsListContract.View> provideViewProvider;

    private Provider<ContactsListPresenter> contactsListPresenterProvider;

    private ContactsListComponentImpl(ViewModule viewModuleParam) {

      initialize(viewModuleParam);
    }

    @SuppressWarnings("unchecked")
    private void initialize(final ViewModule viewModuleParam) {
      this.provideViewProvider = ViewModule_ProvideViewFactory.create(viewModuleParam);
      this.contactsListPresenterProvider = DoubleCheck.provider(ContactsListPresenter_Factory.create(provideViewProvider, DaggerAppComponent.this.provideRepositoryProvider));
    }

    @Override
    public void inject(ContactsListFragment fragment) {
      injectContactsListFragment(fragment);}

    private ContactsListFragment injectContactsListFragment(ContactsListFragment instance) {
      ContactsListFragment_MembersInjector.injectPresenter(instance, contactsListPresenterProvider.get());
      return instance;
    }
  }

  private final class ContactDetailComponentFactory implements ContactDetailComponent.Factory {
    @Override
    public ContactDetailComponent create(
        net.synapticweb.callrecorder.contactdetail.di.ViewModule module) {
      Preconditions.checkNotNull(module);
      return new ContactDetailComponentImpl(module);
    }
  }

  private final class ContactDetailComponentImpl implements ContactDetailComponent {
    private Provider<ContactDetailContract.View> provideViewProvider;

    private Provider<ContactDetailPresenter> contactDetailPresenterProvider;

    private ContactDetailComponentImpl(
        net.synapticweb.callrecorder.contactdetail.di.ViewModule viewModuleParam) {

      initialize(viewModuleParam);
    }

    @SuppressWarnings("unchecked")
    private void initialize(
        final net.synapticweb.callrecorder.contactdetail.di.ViewModule viewModuleParam) {
      this.provideViewProvider = net.synapticweb.callrecorder.contactdetail.di.ViewModule_ProvideViewFactory.create(viewModuleParam);
      this.contactDetailPresenterProvider = DoubleCheck.provider(ContactDetailPresenter_Factory.create(provideViewProvider, DaggerAppComponent.this.provideRepositoryProvider));
    }

    @Override
    public void inject(ContactDetailFragment fragment) {
      injectContactDetailFragment(fragment);}

    private ContactDetailFragment injectContactDetailFragment(ContactDetailFragment instance) {
      ContactDetailFragment_MembersInjector.injectPresenter(instance, contactDetailPresenterProvider.get());
      return instance;
    }
  }
}
